using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace TestApplication
{
    class HHU
    {
        private List<String> categories;
        public List<String> Categories
        {
            get
            {
                return categories;
            }
            set
            {
                categories = value;
            }
        }
        private List<String> alphabet;
        public List<String> Alphabet
        {
            get
            {
                return alphabet;
            }
            set
            {
                alphabet = value;
            }
        }
        public HHU()
        {
            List<String> lstTemp = new List<String>();
            using (StreamReader ioReader = new StreamReader(Properties.Settings.Default.CatFile))
            {
                string line;
                while ((line = ioReader.ReadLine()) != null)
                {
                    lstTemp.Add(line);
                }
                ioReader.Close();
            }
            if (lstTemp != null)
            {
                lstTemp.Sort();
                Categories = lstTemp;
            }
            List<String> lstTemp2 = new List<String>();
            using (StreamReader ioReader = new StreamReader(Properties.Settings.Default.AlphaFile))
            {
                string line;
                while ((line = ioReader.ReadLine()) != null)
                {
                    lstTemp2.Add(line);
                }
                ioReader.Close();
            }
            if (lstTemp2 != null)
            {
                alphabet = lstTemp2;
            }
        }

        public List<String> Picker(List<String> input, int required)
        {
            List<String> output = new List<String>();
            Random rnd = new Random();
            int pos = 0;
            int count = required;
            int total = input.Count();
            int running = total;
            double thres = (double)count / (double)total;
            while (thres > 0 && pos < total)
            {
                if (((double)rnd.Next(0, 1000) / 1000) <= thres)
                {
                    output.Add(input[pos]);
                    count--;
                }
                running--;
                pos++;
                thres = (double)count / ((double)running);
            }
            return output;
        }
        public List<String> Remove(List<String> lstIncoming1, List<String> lstIncoming2)
        {
            List<String> lstOutput = new List<string>();
            int intCount = 0;
            lstIncoming1.Sort();
            lstIncoming2.Sort();
            foreach (String strIncoming in lstIncoming1)
            {
                if (intCount < lstIncoming2.Count)
                {
                    if (lstIncoming2[intCount] != strIncoming)
                    {
                        lstOutput.Add(strIncoming);
                    }
                    else
                    {
                        intCount++;
                    }
                }
                else
                {
                    lstOutput.Add(strIncoming);
                }
            }
            return lstOutput;
        }
        public List<String> Remove(List<String> lstIncoming)
        {
            List<String> lstOuput = this.Remove(this.Categories, lstIncoming);
            return lstOuput;
        }
    }
}

