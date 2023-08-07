using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace OBCtracerB3_20230806
{
    public partial class Form1 : Form
    {
        string primaData;
        string oraTrafCLC, oraTrafDC, oraFilter, oraMicroIO, oraMicroC, oraCapaP, oraCapaN, oraPower;

        

        bool f1, f2, f3, f4, f5, f6, f7, f8, f9=false;//fanion pentru modificarea orei in xml in caz ca pcb-ul a fost scant deja
        bool p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11 = false;//fanion pentru schibarea pozei
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Utilitati uti = new Utilitati();
            if (File.Exists(uti.CautFisier() + "Produse\\" + txtNrProdus.Text.ToString() + "_OBC.xml"))
            {
                XElement xElement = XElement.Load(uti.CautFisier() + "Produse\\" + txtNrProdus.Text.ToString() + "_OBC.xml");
                primaData = (string)xElement.Element("DataAsamblare");

                if (xElement.Element("PCBs").Element("TrafCLC").Value.Length >= 1)
                {
                    f1 = true;
                    uti.TrafCLC = (string)xElement.Element("PCBs").Element("TrafCLC");
                    oraTrafCLC = (string)xElement.Element("oraAsamblare").Element("oraTrafCLC");
                    txtTLLC.Text = uti.TrafCLC;
                    txtTLLC.BackColor = Color.LightGreen;
                    txtTLLC.ReadOnly = true;

                }
                if (xElement.Element("PCBs").Element("TrafDC").Value.Length > 1)
                {
                    f2 = true;
                    uti.TrafDC = (string)xElement.Element("PCBs").Element("TrafDC");
                    oraTrafDC = (string)xElement.Element("oraAsamblare").Element("oraTrafDC");
                    txtTDCDC.Text = uti.TrafDC;
                    txtTDCDC.BackColor = Color.LightGreen;
                    txtTDCDC.ReadOnly = true;

                }
                if (xElement.Element("PCBs").Element("Filter").Value.Length > 1)
                {
                    f3 = true;
                    uti.Filter = (string)xElement.Element("PCBs").Element("Filter");
                    oraFilter = (string)xElement.Element("oraAsamblare").Element("oraFilter");
                    txtFilter.Text = uti.Filter;
                    txtFilter.BackColor = Color.LightGreen;
                    txtFilter.ReadOnly = true;
                }
                if (xElement.Element("PCBs").Element("MicroIO").Value.Length >= 1)
                {
                    f4 = true;
                    uti.MicroIO = (string)xElement.Element("PCBs").Element("MicroIO");
                    oraMicroIO = (string)xElement.Element("oraAsamblare").Element("oraMicroIO");
                    txtMIO.Text = uti.MicroIO;
                    txtMIO.BackColor = Color.LightGreen;
                    txtMIO.ReadOnly = true;

                }
                if (xElement.Element("PCBs").Element("MicroC").Value.Length > 1)
                {
                    f5 = true;
                    uti.MicroC = (string)xElement.Element("PCBs").Element("MicroC");
                    oraMicroC = (string)xElement.Element("oraAsamblare").Element("oraMicroC");
                    txtMC.Text = uti.MicroC;
                    txtMC.BackColor = Color.LightGreen;
                    txtMC.ReadOnly = true;

                }
                if (xElement.Element("PCBs").Element("CapaP").Value.Length > 1)
                {
                    f6 = true;
                    uti.CapaP = (string)xElement.Element("PCBs").Element("CapaP");
                    oraCapaP = (string)xElement.Element("oraAsamblare").Element("oraCapaP");
                    txtPC.Text = uti.CapaP;
                    txtPC.BackColor = Color.LightGreen;
                    txtPC.ReadOnly = true;
                }
                if (xElement.Element("PCBs").Element("CapaN").Value.Length >= 1)
                {
                    f7 = true;
                    uti.CapaN = (string)xElement.Element("PCBs").Element("CapaN");
                    oraCapaN = (string)xElement.Element("oraAsamblare").Element("oraCapaN");
                    txtNC.Text = uti.CapaN;
                    txtNC.BackColor = Color.LightGreen;
                    txtNC.ReadOnly = true;

                }
                if (xElement.Element("PCBs").Element("Power").Value.Length > 1)
                {
                    f8 = true;
                    uti.Power = (string)xElement.Element("PCBs").Element("Power");
                    oraPower = (string)xElement.Element("oraAsamblare").Element("oraPower");
                    txtPower.Text = uti.Power;
                    txtPower.BackColor = Color.LightGreen;
                    txtPower.ReadOnly = true;

                }
            }
            else
            {
                primaData = uti.ReturnezData(1);
            }
        }
        private void txtTLLC_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtTDCDC_TextChanged(object sender, EventArgs e)
        {

        }
         private void txtFilter_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtMIO_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMC_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPC_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNC_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPower_TextChanged(object sender, EventArgs e)
        {

        }

    

       
    }
}
