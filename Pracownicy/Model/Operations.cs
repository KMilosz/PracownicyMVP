using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Pracownicy.Model
{
    static class Operations
    {
        public static string Add(string name, string lastname, string date, string salary, string position, string contract) => name + ";" + lastname + ";" + date + ";" + salary + ";" + position + ";" + contract + ";";
    }
    class WorkerBuilder
    {
        private static View.Form1 _view;
        private string _workertext, _workername = "", _workerlastname = "", _workerdate = DateTime.Today.ToString(), _workersalary = "1000", _workerposition = "Inżynier", _workercontract = "umowa na czas nieokreślony";
        public string WorkerText => _workertext;
        public string WorkerName => _workername;
        public string WorkerLastname => _workerlastname;
        public string WorkerDate => _workerdate;
        public string WorkerSalary => _workersalary;
        public string WorkerPosition => _workerposition;
        public string WorkerContract => _workercontract;
        public WorkerBuilder(View.Form1 view)
        {
            _view = view;
        }
        public WorkerBuilder(string text)
        {
            _workertext = text;
        }
        public WorkerBuilder()
        {
            _workertext = null;
        }
        public WorkerBuilder NameChange(string i)
        {
            _workername = i;
            return this;
        }
        public WorkerBuilder LastnameChange(string i)
        {
            _workerlastname = i;
            return this;
        }
        public WorkerBuilder DateChange(string i)
        {
            _workerdate = i;
            return this;
        }
        public WorkerBuilder NumericUpDownChange(string i)
        {
            _workersalary = i;
            return this;
        }
        public WorkerBuilder ComboBoxChange(string i)
        {
            _workerposition = i;
            return this;
        }
        public WorkerBuilder RadioButtonChange(string i)
        {
            _workercontract = i;
            return this;
        }
        public void LoadData(string text)
        {
            string[] splitedText = text.Split(';');
            string name = splitedText[0];
            string lastname = splitedText[1];
            string date = splitedText[2];
            string salary = splitedText[3];
            string position = splitedText[4];
            string contract = splitedText[5];
            int positionIndex;
            if (position == "Tester")
                positionIndex = 0;
            else if (position == "Projektant")
                positionIndex = 1;
            else if (position == "Inżynier")
                positionIndex = 2;
            else if (position == "Młodszy programista")
                positionIndex = 3;
            else
                positionIndex = 4;
            if (contract == "umowa na czas nieokreślony")
                _view.setValues(name, lastname, DateTime.Parse(date), int.Parse(salary), positionIndex, true, false, false);
            else if (contract == "umowa na czas określony")
                _view.setValues(name, lastname, DateTime.Parse(date), int.Parse(salary), positionIndex, false, true, false);
            else
                _view.setValues(name, lastname, DateTime.Parse(date), int.Parse(salary), positionIndex, false, false, true);
        }
        public void Serialization()
        {
            XmlDocument xml = new XmlDocument();

            XmlElement root = xml.CreateElement("Data");


            string[] items = _view.DisplayText.Split(',');

            foreach (string item in items)
            {
                XmlElement child = xml.CreateElement("Item");
                child.InnerText = item;

                root.AppendChild(child);
            }

            xml.AppendChild(root);

            string fileName = "Pracownicy.xml";
            using (StreamWriter stream = new StreamWriter(fileName))
            {
                xml.Save(stream);
            }
        }
        public void Deserialization()
        {
            XmlDocument xml = new XmlDocument();
            xml.Load("Pracownicy.xml");
            XmlElement root = xml.DocumentElement;
            foreach (XmlNode node in root.ChildNodes)
            {
                _view.DisplayText = node.InnerText;
            }
        }
    }
}
