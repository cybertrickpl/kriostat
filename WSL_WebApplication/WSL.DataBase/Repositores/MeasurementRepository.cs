using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wsl.Common.Dto;
using WSL.DataBase.Tables;

namespace WSL.DataBase.Repositores
{
    public class MeasurementRepository
    {
        private readonly WSLDBContext _context;
        public MeasurementRepository(WSLDBContext context)
        {
            _context = context;
        }

        public int UploadValues(string FileContentBase64)
        {
            

            try
            {
                byte[] fileContentByte = System.Convert.FromBase64String(FileContentBase64);
                string fileContentStr = System.Text.Encoding.UTF8.GetString(fileContentByte);

                string[] lines = fileContentStr.Split(System.Environment.NewLine);

                List<string> data = new List<string>();

                

                for (int x = 2; x < lines.Count(); x++)
                {
                    data.Add(lines[x]);
                }

                foreach (var row in data)
                {
                    
                    string[] cols = row.Split(' ');
                    if (cols.Length > 1)
                    {
                        Measurement measurement = new Measurement();
                        measurement.Temp = 23;

                        if (cols[0].Contains("e+0"))
                        {
                                                 
                            string[] freq = cols[0].Split("e+0");
                                                       
                            measurement.Frequency = Convert.ToDouble(freq[0].Replace(".", ",")) *Math.Pow(10, Convert.ToDouble(freq[1]));
                        }
                        else measurement.Frequency = Convert.ToDouble(cols[0].Replace(".", ","));

                        measurement.Impedance = Convert.ToDouble(cols[1].Replace(".",","));
                        measurement.Phase = Convert.ToDouble(cols[2].Replace(".", ","));

                        _context.Measurements.Add(measurement);
                        

                    }

                    _context.SaveChanges();

                }
                
            }catch (Exception ex)
            {
                ex.ToString();
            }

            return 3;
        }
    }      
}
