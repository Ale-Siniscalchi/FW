using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml; 
using System.IO;
using System.Net;
using System.Net.NetworkInformation;


namespace FWUpdate
{
    public partial class Form1 : Form
    {
        string tecnico;
        bool flag = false;
        bool statusResponse = false;
        bool statusPrinter = false;
        string firmware;
        string esito;
        int pingcounter = 0;
        public Form1()
        {
            InitializeComponent();
            Start();
           
        }
        public void Start()
        {
            setUrlBtn.Enabled = false;
            SignBtn.Enabled = false;
            UpdateBtn.Enabled = false;
            txtIP.Enabled = true;
            comboBox2.Enabled = true;
            //percorso txt lista tecnici
            string fullpath = "lista.txt";
            //popolo la combobox
            try
            {
                comboBox2.Items.AddRange(File.ReadAllLines(fullpath));
                comboBox2.SelectedIndex = 0;
            }
            catch
            {
                MessageBox.Show("File Lista Tecnici Non trovato, inserire dato a mano, solo Codice Fiscale");
            }

            IsAnIp();
        }
        //Imposto il file .MOT
        public string ExecuteSetUrl()
        {
            string soapResult = String.Empty;
            HttpWebRequest request = CreateWebRequest(@"http://" + txtIP.Text + "/cgi-bin/fpmate.cgi?");
            request.Timeout = 2000;
            XmlDocument soapEnvelopeXml = new XmlDocument();

            soapEnvelopeXml.LoadXml("<?xml version='1.0' encoding ='utf-8'?>" +
                "<soap:Envelope xmlns:soap='http://schemas.xmlsoap.org/soap/envelope/' " +
                         "       xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' " +
                         "       xmlns:xsd='http://www.w3.org/2001/XMLSchema' " +
                         "       xmlns:tns='http://localhost:8080/ws-doc/'>" +
                "<soap:Body>" +
                    "<printerCommand>" +
                        "<directIO command='9010' data='0" + txtURL.Text + " '/>" +
                    "</printerCommand>" +
                "</soap:Body>" +
                "</soap:Envelope>");
            using (Stream stream = request.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                {
                    soapResult = rd.ReadToEnd();
                    System.Diagnostics.Debug.WriteLine(soapResult);
                }
            }
            return soapResult;
        }
        //Imposto il file .Sig
        public string ExecuteSetSign()
        {
            string soapResult = String.Empty;
            HttpWebRequest request = CreateWebRequest(@"http://" + txtIP.Text + "/cgi-bin/fpmate.cgi?");
            request.Timeout = 2000;
            XmlDocument soapEnvelopeXml = new XmlDocument();

            soapEnvelopeXml.LoadXml("<?xml version='1.0' encoding ='utf-8'?>" +
                "<soap:Envelope xmlns:soap='http://schemas.xmlsoap.org/soap/envelope/' " +
                         "       xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' " +
                         "       xmlns:xsd='http://www.w3.org/2001/XMLSchema' " +
                         "       xmlns:tns='http://localhost:8080/ws-doc/'>" +
                "<soap:Body>" +
                    "<printerCommand>" +
                        "<directIO command='9010' data='1" + txtSign.Text + " '/>" +
                    "</printerCommand>" +
                "</soap:Body>" +
                "</soap:Envelope>");

            using (Stream stream = request.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                {
                    soapResult = rd.ReadToEnd();
                    System.Diagnostics.Debug.WriteLine(soapResult);
                }
            }
            return soapResult;
        }
        //Eseguo la scrittura
        public string ExecuteWriting()
        {
            string soapResult = String.Empty;
            HttpWebRequest request = CreateWebRequest(@"http://" + txtIP.Text + "/cgi-bin/fpmate.cgi?");
            request.Timeout = 2000;
            XmlDocument soapEnvelopeXml = new XmlDocument();
            tecnico = comboBox2.GetItemText(comboBox2.SelectedItem).Substring(0, 16);
            soapEnvelopeXml.LoadXml("<?xml version='1.0' encoding ='utf-8'?>" +
                "<soap:Envelope xmlns:soap='http://schemas.xmlsoap.org/soap/envelope/' " +
                         "       xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' " +
                         "       xmlns:xsd='http://www.w3.org/2001/XMLSchema' " +
                         "       xmlns:tns='http://localhost:8080/ws-doc/'>" +
                "<soap:Body>" +
                    "<printerCommand>" +
                        "<directIO command='9011' data='" + tecnico + "IT07450300632epson     epson     0123'/>" +
                    "</printerCommand>" +
                "</soap:Body>" +
                "</soap:Envelope>");
            try
            {
                using (Stream stream = request.GetRequestStream())
                {
                    soapEnvelopeXml.Save(stream);
                }

                using (WebResponse response = request.GetResponse())
                {
                    using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                    {
                        soapResult = rd.ReadToEnd();
                        System.Diagnostics.Debug.WriteLine(soapResult);

                    }
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = "Stampante Offline";
            }
            return soapResult;
        }
        //Risposta alla chiamata SOAP 1074 per capire lo stato della stampante
        public string ExecuteCheckStatus()
        {
            string soapResult = String.Empty;
            HttpWebRequest request = CreateWebRequest(@"http://" + txtIP.Text + "/cgi-bin/fpmate.cgi?");
            request.Timeout = 2000;
            XmlDocument soapEnvelopeXml = new XmlDocument();

            soapEnvelopeXml.LoadXml("<?xml version='1.0' encoding ='utf-8'?>" +
                "<soap:Envelope xmlns:soap='http://schemas.xmlsoap.org/soap/envelope/' " +
                         "       xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' " +
                         "       xmlns:xsd='http://www.w3.org/2001/XMLSchema' " +
                         "       xmlns:tns='http://localhost:8080/ws-doc/'>" +
                "<soap:Body>" +
                    "<printerCommand>" +
                        "<directIO command='1074' operator= '01'/>" +
                    "</printerCommand>" +
                "</soap:Body>" +
                "</soap:Envelope>");

            try
            {
                using (Stream stream = request.GetRequestStream())
                {
                    soapEnvelopeXml.Save(stream);
                }

                using (WebResponse response = request.GetResponse())
                {
                    using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                    {
                        soapResult = rd.ReadToEnd();
                        System.Diagnostics.Debug.WriteLine(soapResult);
                    }
                }
            }
            catch (Exception)
            {
                toolStripStatusLabel1.Text = "Stampante Offline";
            }
            return soapResult;
        }
        //Controllo se è un ip
        public bool IsAnIp()
        {
            UpdateBtn.Enabled = false;
            SignBtn.Enabled = false;
            setUrlBtn.Enabled = false;
            flag = false;
            flag = IPAddress.TryParse(txtIP.Text, out IPAddress address);
            string[] splitvalues = txtIP.Text.Split('.');

            if (splitvalues.Length == 4 && flag == true)
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                Ping ping = new Ping();
                PingReply reply = ping.Send(txtIP.Text, 1000);
                var res = ExecuteCheckStatus();
                IsAprinter(res);
                if (reply.Status.ToString() == "Success" && statusPrinter == true)
                {
                    txtIP.BackColor = Color.LightGreen;
                    flag = true;
                }
                else
                {
                    richTextBox1.Clear();
                    txtIP.BackColor = Color.Red;
                }
            }
            else
            {
                richTextBox1.Clear();
                txtIP.BackColor = Color.Red;
            }
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
            return flag;
        }
        //Controllo se è una stampante
        public bool IsAprinter(string res)
        {
            XmlDocument doc = new XmlDocument();
            statusPrinter = false;
            richTextBox1.Clear();
            try
            {
                doc.LoadXml(res);
                var nodes = doc.GetElementsByTagName("responseData");
                firmware = nodes[0].InnerText;
                firmware = firmware.Substring(2, 4);
                toolStripStatusLabel1.Text = "Stampante Connessa";
                richTextBox1.AppendText("Stampante Connessa" + Environment.NewLine);
                richTextBox1.AppendText("Versione Firmware Attuale " + firmware + Environment.NewLine);
                setUrlBtn.Enabled = true;
                statusPrinter = true;
            }
            catch
            {
                setUrlBtn.Enabled = false;
                richTextBox1.Clear();
                richTextBox1.AppendText("L'IP selezionato non è una stampante");
            }
            return statusPrinter;
        }
        //Gestisco la Response Soap
        public bool ResponseManager(string res)
        {
            statusResponse = false;
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.LoadXml(res);
                var nodes = doc.GetElementsByTagName("response");
                if (nodes[0].Attributes["success"].Value == "true")
                {
                    statusResponse = true;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Stampante Offline";
                    statusResponse = false;
                }
            }
            catch
            {
                toolStripStatusLabel1.Text = "Stampante Offline";
                statusResponse = false;
            }
            return statusResponse;
        }
        public string ExecuteRtStatus()
        {
            string soapResult = String.Empty;
            HttpWebRequest request = CreateWebRequest(@"http://" + txtIP.Text + "/cgi-bin/fpmate.cgi?");
            request.Timeout = 2000;
            XmlDocument soapEnvelopeXml = new XmlDocument();

            soapEnvelopeXml.LoadXml("<?xml version='1.0' encoding ='utf-8'?>" +
                "<soap:Envelope xmlns:soap='http://schemas.xmlsoap.org/soap/envelope/' " +
                         "       xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' " +
                         "       xmlns:xsd='http://www.w3.org/2001/XMLSchema' " +
                         "       xmlns:tns='http://localhost:8080/ws-doc/'>" +
                "<soap:Body>" +
                    "<printerCommand>" +
                        "<directIO command='1138' operator= '01'/>" +
                    "</printerCommand>" +
                "</soap:Body>" +
                "</soap:Envelope>");

            try
            {
                using (Stream stream = request.GetRequestStream())
                {
                    soapEnvelopeXml.Save(stream);
                }

                using (WebResponse response = request.GetResponse())
                {
                    using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                    {
                        soapResult = rd.ReadToEnd();
                        System.Diagnostics.Debug.WriteLine(soapResult);
                    }
                }
                XmlDocument doc = new XmlDocument();
                statusPrinter = false;
                richTextBox1.Clear();
                doc.LoadXml(soapResult);
                var nodes = doc.GetElementsByTagName("responseData");
                esito = nodes[0].InnerText;
                esito = esito.Substring(39, 1);                
           }
            catch (Exception)
            {
                toolStripStatusLabel1.Text = "Stampante Offline";
            }            
            return esito;
        }

        //webrequest per realizzare le chiamate SOAP
        public HttpWebRequest CreateWebRequest(string indirizzoIP)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(indirizzoIP);
            webRequest.Headers.Add(@"SOAP:Action");
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }

        private void SetUrlBtn_Click(object sender, EventArgs e)
        {
            SignBtn.Enabled = false;
            Uri uriResult;
            bool result = Uri.TryCreate(txtURL.Text, UriKind.Absolute, out uriResult)
               && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            if (result && txtURL.Text.EndsWith(".mot"))
            {                
                var res = ExecuteSetUrl();
                ResponseManager(res);
                if (statusResponse == true)
                {
                    richTextBox1.AppendText("File MOT impostato correttamente " + Environment.NewLine);
                    SignBtn.Enabled = true;
                }
            }
            else
            {
                richTextBox1.Clear();
                richTextBox1.AppendText("L'Url Indicato non è Valido" + Environment.NewLine);
            }

        }

        private void SignBtn_Click(object sender, EventArgs e)
        {
            UpdateBtn.Enabled = false;
            Uri uriResult;
            bool result = Uri.TryCreate(txtSign.Text, UriKind.Absolute, out uriResult)
               && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            if (result && txtURL.Text.EndsWith(".sig"))
            {
                var res = ExecuteSetSign();
                ResponseManager(res);
                if (statusResponse == true)
                {
                    richTextBox1.AppendText("File SIG impostato correttamente " + Environment.NewLine);
                    UpdateBtn.Enabled = true;
                }
            }
            else
            {
                richTextBox1.Clear();
                richTextBox1.AppendText("L'Url Indicato non è Valido" + Environment.NewLine);
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            var res = ExecuteWriting();
            ResponseManager(res);
            richTextBox1.AppendText("Scrittura in corso Attendere Circa 10 minuti" + Environment.NewLine);
            txtIP.Enabled = false;
            setUrlBtn.Enabled = false;
            SignBtn.Enabled = false;
            UpdateBtn.Enabled = false;
            comboBox2.Enabled = false;
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.MarqueeAnimationSpeed = 30;
            timer1.Enabled = true;
            timer1.Interval = 5000;
            timer1.Tick += Timer1_Tick;
        }

        private void CheckBtn_Click(object sender, EventArgs e)
        {
            //ExecuteIsAprinter();
            var res = ExecuteCheckStatus();
            IsAprinter(res);

        }

        private void TxtIP_TextChanged(object sender, EventArgs e)
        {
            IsAnIp();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {

             Task mytask = Task.Run(() =>
            {
                var res = ExecuteCheckStatus();
                Ping ping = new Ping();
                PingReply reply = ping.Send(txtIP.Text, 1000);
                if (reply.Status.ToString() == "Success")
                {
                    pingcounter++;
                }
                else if (pingcounter>15)
                {
                    richTextBox1.Clear();
                    richTextBox1.AppendText("Riavvio in corso");
                    pingcounter = 0;
                }
                else
                {
                    progressBar1.Style = ProgressBarStyle.Continuous;
                    progressBar1.MarqueeAnimationSpeed = 0;
                    timer1.Enabled = false;
                    MessageBox.Show("La Stampante Non Risulta Raggiungibile");
                    Start();
                }
                if (ResponseManager(res) == true)
                {
                    progressBar1.Invoke((MethodInvoker)delegate
                    {
                        progressBar1.Style = ProgressBarStyle.Continuous;
                        progressBar1.MarqueeAnimationSpeed = 0;
                        timer1.Enabled = false;
                        var prova=ExecuteRtStatus();
                        
                        
                            switch (prova)
                            {
                                case "0":
                                    richTextBox1.Clear();
                                    richTextBox1.AppendText("Aggiornamento Completato " + Environment.NewLine);
                                    IsAprinter(res);
                                    MessageBox.Show("Aggiornamento Completato, Versione Attuale: " + firmware);
                                    Start();
                                    break;
                                case "1":
                                    MessageBox.Show("Errore Nel Download del Firmware controllare Validità link");
                                    Start();
                                    break;
                                case "2":
                                    MessageBox.Show("Errore: Firma Non Valida");
                                    Start();
                                    break;
                                case "3":
                                    MessageBox.Show("Errore: File .Mot Non Valido");
                                    Start();
                                    break;

                            }
                        
                    });
                }
             });

        }
    }
}