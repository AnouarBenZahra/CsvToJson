using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CsvToJson
{
    public class ConvertToJson
    {
        

        public string ConvertCsvFileToJsonObject(string path)
        {
            string json = string.Empty;
            string csv = string.Empty;

            using (StreamReader reader = new StreamReader(path))
            {
                csv = reader.ReadToEnd();
            }

            string[] lines = csv.Split(new string[] { "\n" }, System.StringSplitOptions.None);

            if (lines.Length > 1)
            {
                // parse headers
                string[] headers = lines[0].Split(',');

                StringBuilder sbjson = new StringBuilder();
                sbjson.Clear();
                sbjson.Append("[");

                // parse data
                for (int i = 1; i < lines.Length; i++)
                {
                    if (string.IsNullOrWhiteSpace(lines[i])) continue;
                    if (string.IsNullOrEmpty(lines[i])) continue;

                    sbjson.Append("{");

                    string[] data = lines[i].Split(',');

                    for (int h = 0; h < headers.Length; h++)
                    {
                        sbjson.Append(
                            $"\"{headers[h]}\": \"{data[h]}\"" + (h < headers.Length - 1 ? "," : null)
                        );
                    }

                    sbjson.Append("}" + (i < lines.Length - 1 ? "," : null));
                }

                sbjson.Append("]");

                json = sbjson.ToString();
            }

            return json;
        }
    }



    }

