using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace OBCtracerB3_20230806
{
    internal class Utilitati
    {
        public int NrProdus { get; set; }
        public string DataAsamblare { get; set; }
        public string StatieAsamblare { get; set; }
        public string TrafCLC { get; set; }
        public string TrafDC { get; set; }
        public string Filter { get; set; }
        public string MicroIO { get; set; }
        public string MicroC { get; set; }
        public string CapaP { get; set; }
        public string CapaN { get; set; }
        public string Power { get; set; }
        public string oraTrafCLC { get; set; }
        public string oraTrafDC { get; set; }
        public string oraFilter { get; set; }
        public string oraMicroIO { get; set; }
        public string oraMicroC { get; set; }
        public string oraCapaP { get; set; }
        public string oraCapaN { get; set; }
        public string oraPower { get; set; }

        public Utilitati(int nrProdus, string dataAsamblare, string statieAsamblare, string trafCLC, string trafDC, string filter, string microIO, string microC, string capaP, string capaN, string power, string oraTrafCLC, string oraTrafDC, string oraFilter, string oraMicroIO, string oraMicroC, string oraCapaP, string oraCapaN, string oraPower)
        {
            NrProdus = nrProdus;
            DataAsamblare = dataAsamblare;
            StatieAsamblare = statieAsamblare;
            TrafCLC = trafCLC;
            TrafDC = trafDC;
            Filter = filter;
            MicroIO = microIO;
            MicroC = microC;
            CapaP = capaP;
            CapaN = capaN;
            Power = power;
            this.oraTrafCLC = oraTrafCLC;
            this.oraTrafDC = oraTrafDC;
            this.oraFilter = oraFilter;
            this.oraMicroIO = oraMicroIO;
            this.oraMicroC = oraMicroC;
            this.oraCapaP = oraCapaP;
            this.oraCapaN = oraCapaN;
            this.oraPower = oraPower;
        }
        public Utilitati()
        {

        }

        public string ReturnezData(int n)
        {
            string datac;
            switch (n)
            {
                case 1:
                    datac = DateTime.Now.ToString("dd.MM.yyyy@HH:mm", CultureInfo.InvariantCulture);
                    return datac;
                    break;
                case 2:
                    datac = DateTime.Now.ToString("HH:mm", CultureInfo.InvariantCulture);
                    return datac;
                    break;
                default:
                    datac = DateTime.Now.ToString("dd.MM.yyyy@HH:mm", CultureInfo.InvariantCulture);
                    return datac;
                    break;
            }
        }

        public string CautFisier()
        {
            string dir;
            dir = AppDomain.CurrentDomain.BaseDirectory;
            return dir;
        }

        public void IncartDocument()
        {
            XElement xElement = XElement.Load(CautFisier() + "Produse\\" + NrProdus + "_OBC.xml");
        }
        public void CreezFisier()
        {
            if (!Directory.Exists(CautFisier() + "Produse"))
            {
                Directory.CreateDirectory(CautFisier() + "Produse");
            }
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = ("    ");
            settings.CloseOutput = true;
            settings.OmitXmlDeclaration = true;
            XmlWriter writer = XmlWriter.Create(CautFisier() + "Produse\\" + NrProdus + "_OBC.xml", settings);
            writer.WriteStartDocument();
            writer.WriteStartElement("DetaliiProdus_" + NrProdus.ToString()+"OBC_B3_11kW");
            writer.WriteElementString("NumarProdus", NrProdus.ToString());
            writer.WriteElementString("DataAsamblare", DataAsamblare.ToString());
            writer.WriteElementString("StatieAsamblare", Environment.UserName.ToString()+"YCT");
            writer.WriteStartElement("PCBs");
            writer.WriteElementString("Traf_CLLLC", TrafCLC.ToString());
            writer.WriteElementString("Traf_DCDC", TrafDC.ToString());
            writer.WriteElementString("Filter", Filter.ToString());
            writer.WriteElementString("Micro_IO", MicroIO.ToString());
            writer.WriteElementString("Micro_Ctr", MicroC.ToString());
            writer.WriteElementString("Positive_Capacitor", CapaP.ToString());
            writer.WriteElementString("Negative_Capacitor", CapaN.ToString());
            writer.WriteElementString("Power", Power.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("oraAsamblare");
            writer.WriteElementString("oraTraf_CLLLC", oraTrafCLC.ToString());
            writer.WriteElementString("oraTraf_DCDC", oraTrafDC.ToString());
            writer.WriteElementString("oraFilter", oraFilter.ToString());
            writer.WriteElementString("oraMicro_IO", oraMicroIO.ToString());
            writer.WriteElementString("oraMicro_Ctr", oraMicroC.ToString());
            writer.WriteElementString("oraPositive_Capacitor", oraCapaP.ToString());
            writer.WriteElementString("oraNegative_Capacitor", oraCapaN.ToString());
            writer.WriteElementString("oraPower", oraPower.ToString());
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();

        }

    }
}
