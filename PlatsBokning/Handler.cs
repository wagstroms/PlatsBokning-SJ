using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.IO;

namespace PlatsBokning
{
    internal class Handler
    {
        public void Save() //sprarar listan med lagen.
        {

            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;

            using (StreamWriter sw = new StreamWriter(@"seatData.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, Program.seats);
            }

        }

        public void Load() //laddar in datan  / objekt från listan med lag. lagList
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;


            using (StreamReader file = File.OpenText(@"seatData.json"))
            {
                Program.seats = JsonConvert.DeserializeObject<List<Seat>>(File.ReadAllText(@"seatData.json"));
                serializer = new JsonSerializer();
                Program.seats = (List<Seat>)serializer.Deserialize(file, typeof(List<Seat>));
            }
        }
    }
}
