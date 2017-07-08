using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Data;

namespace Controles2016
{
    static class IOarchivos
    {
        public static void writeJson(string file, object theObj)
        {
            File.WriteAllText(file, JsonConvert.SerializeObject(theObj));
        }

        public static void appendJson<T>(string file, object theObj)
        {
            List<T> lista = readJsonList<T>(file);
            lista.Add((T)theObj);
            File.WriteAllText(file, JsonConvert.SerializeObject(lista));
        }

        public static List<T> readJsonList<T>(string file)
        {
            try
            {
                List<T> lista = JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(file));
                return lista;
            }
            catch (Exception /*error*/)
            {
                //MessageBox.Show("Catch de ReadJsonList en IOarchivos. Si el siguiente error es que no encontró el archivo, lo creará y escribirá normalmente "+error.Message);
                MessageBox.Show("No existe archivo de registros");
                List<T> lista = new List<T>();
                return lista;
            }
        }



        public static void createCSVFile(ref DataTable dt, string strFilePath)
        {
            try
            {
                // Create the CSV file to which grid data will be exported.
                StreamWriter sw = new StreamWriter(strFilePath, false);
                // First we will write the headers.
                //DataTable dt = m_dsProducts.Tables[0];
                int iColCount = dt.Columns.Count;
                for (int i = 0; i < iColCount; i++)
                {
                    sw.Write(dt.Columns[i]);
                    if (i < iColCount - 1)
                    {
                        sw.Write("|");
                    }
                }
                sw.Write(sw.NewLine);

                // Now write all the rows.

                foreach (DataRow dr in dt.Rows)
                {
                    for (int i = 0; i < iColCount; i++)
                    {
                        if (!Convert.IsDBNull(dr[i]))
                        {
                            sw.Write(dr[i].ToString());
                        }
                        if (i < iColCount - 1)
                        {
                            sw.Write("|");
                        }
                    }

                    sw.Write(sw.NewLine);
                }
                sw.Close();
                MessageBox.Show("excel.csv creado");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw ex;
            }
        }



    }
}
