namespace CsvCleanToUSCharset
{
    using System;
    using System.Collections.Concurrent;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    internal class Processor
    {
        internal static async Task<bool> ProcessFileAsync(FileInfo file, bool skipFirstRow, char separator, char? delimiter, ConcurrentDictionary<int, string> logInfo, CancellationToken token)
        {
            object mylock = new();
            try
            {
                int i = -1;
                int initialSize = (int)(file.Length / 100) + 10;
                string[] addresses = new string[initialSize];
                logInfo.TryAdd(-1, "Start reading file");
                await foreach (var line in File.ReadLinesAsync(file.FullName, token))
                {
                    Interlocked.Increment(ref i);
                    lock (mylock)
                    {
                        if (i > initialSize - 1)
                        {
                            Array.Resize(ref addresses, initialSize + 10);
                            initialSize += 10;
                        }
                    }
                    if (string.IsNullOrEmpty(line)) { continue; }
                    addresses[i] = line;
                    if (i > 0 || !skipFirstRow) { SubstituteChars(ref addresses[i], separator, delimiter, logInfo); }
                }
                logInfo.TryAdd(-10, "Stopped reading file");

                logInfo.TryAdd(-2, "Start writing results file");
                string newName = file.DirectoryName! + "\\" + Path.GetFileNameWithoutExtension(file.FullName) + DateTime.Now.ToString().Replace(':', '-') + file.Extension;
                await File.WriteAllLinesAsync(newName, addresses, token);
                logInfo.TryAdd(-20, "Stopped writing results file");
            }
            catch (AggregateException e)
            {
                throw e.Flatten();
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            return true;
        }

        private static void SubstituteChars(ref string origin, char separator, char? delimiter, ConcurrentDictionary<int, string> logInfo)
        {
            if (origin == null) { return; }

            bool specialCountry = false;
            delimiter ??= separator;

            if (origin.Contains(delimiter + "DE" + delimiter) || origin.Contains(delimiter + "AT" + delimiter) || origin.Contains(delimiter + "CH" + delimiter))
                specialCountry = true;

            StringBuilder sb = new(origin);

            if (specialCountry)
            {
                sb
                    .Replace("Ä", "Ae")
                    .Replace("ä", "ae")
                    .Replace("Ö", "Oe")
                    .Replace("ö", "oe")
                    .Replace("Ü", "Ue")
                    .Replace("ü", "ue");
            }

            sb
                .Replace('Á', 'A')
                .Replace('á', 'a')
                .Replace('À', 'A')
                .Replace('à', 'a')
                .Replace('Â', 'A')
                .Replace('â', 'a')
                .Replace('Ã', 'A')
                .Replace('ã', 'a')
                .Replace('Ä', 'A')
                .Replace('ä', 'a')
                .Replace('Â', 'A')
                .Replace('â', 'a')
                .Replace('Ç', 'C')
                .Replace('ç', 'c')
                .Replace('É', 'E')
                .Replace('é', 'e')
                .Replace('È', 'E')
                .Replace('è', 'e')
                .Replace('Ê', 'E')
                .Replace('ê', 'e')
                .Replace('Ë', 'E')
                .Replace('ë', 'e')
                .Replace('Í', 'I')
                .Replace('í', 'i')
                .Replace('Ì', 'I')
                .Replace('ì', 'i')
                .Replace('Î', 'I')
                .Replace('î', 'i')
                .Replace('Ï', 'I')
                .Replace('ï', 'i')
                .Replace('Ð', 'D')
                .Replace('ð', 'd')
                .Replace('Ñ', 'N')
                .Replace('ñ', 'n')
                .Replace('Ó', 'O')
                .Replace('ó', 'o')
                .Replace('Ò', 'O')
                .Replace('ò', 'o')
                .Replace('Ô', 'O')
                .Replace('ô', 'o')
                .Replace('Õ', 'O')
                .Replace('õ', 'o')
                .Replace('Ö', 'O')
                .Replace('ö', 'o')
                .Replace('Ø', 'O')
                .Replace('ø', 'o')
                .Replace('Ú', 'U')
                .Replace('ú', 'u')
                .Replace('Ù', 'U')
                .Replace('ù', 'u')
                .Replace('Û', 'U')
                .Replace('û', 'u')
                .Replace('Ü', 'U')
                .Replace('ü', 'u')
                .Replace('Ý', 'Y')
                .Replace('ý', 'y')
                .Replace('ÿ', 'y')
                .Replace("Å", "A")
                .Replace("å", "a")
                .Replace("Æ", "Ae")
                .Replace("æ", "ae")
                .Replace("ß", "ss")
                .Replace("Þ", "Th")
                .Replace("þ", "th");

            origin = sb.ToString();
        }
    }
}