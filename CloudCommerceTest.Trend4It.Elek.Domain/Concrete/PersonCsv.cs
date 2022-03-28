using CloudCommerceTest.Trend4It.Elek.Domain.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CloudCommerceTest.Trend4It.Elek.Domain.Concrete
{
    public class PersonCsv : IPerson
    {

        public string[] GetData(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException($"'{nameof(path)}' cannot be null or empty.", nameof(path));
            }

            var file = Directory.GetFiles(path, "*.csv").FirstOrDefault();

            string[] contents = null;
            if (file != null)
            {
                contents = File.ReadAllLines(file);
            }

            return contents;
        }

        private string CsvToJson(string[] csvValues)
        {
            var csv = new List<string[]>();

            foreach (string line in csvValues)
                csv.Add(line.Split(','));

            var properties = csvValues[0].Split(',');

            var listObjResult = new List<Dictionary<object, object>>();
            var childObj = new Dictionary<string, string>();

            for (int i = 1; i < csvValues.Length; i++)
            {
                var objResult = new Dictionary<object, object>();

                for (int j = 0; j < properties.Length; j++)
                {
                    if (properties[j].Contains("_"))
                    {
                        childObj.Add(properties[j].Split("_")[1], csv[i][j]);
                    }
                    else
                    {
                        objResult.Add(properties[j], csv[i][j]);
                    }
                }

                objResult.Add(properties[1].Split("_")[0], childObj);

                listObjResult.Add(objResult);
            }

            return JsonConvert.SerializeObject(listObjResult, Formatting.Indented);
        }


        public string SaveData(string[] lines)
        {
            var json = CsvToJson(lines);

            return json;
        }
    }
}
