using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pracownicy.Model
{
    class MainModel
    {
        private WorkerBuilder workerBuilderTmp;
        public WorkerBuilder WorkerBuilderTmp
        {
            get {
                if (workerBuilderTmp is null)
                    throw new Exception("Brak danych");
                else
                    return workerBuilderTmp; 
            }
            set { workerBuilderTmp = value; }
        }
        private string? imie;
        public string? Imie
        {
            get => imie;
            set { imie = value; }
        }
        private string? nazwisko;
        public string? Nazwisko
        {
            get => nazwisko;
            set { nazwisko = value; }
        }
        private string? data;
        public string? Data
        {
            get => data;
            set { data = value; }
        }
        private string? pensja = "1000";
        public string? Pensja
        {
            get => pensja;
            set { pensja = value; }
        }
        private string? stanowisko = "Inżynier";
        public string? Stanowisko
        {
            get => stanowisko;
            set { stanowisko = value; }
        }
        private string? umowa = "umowa na czas nieokreślony";
        public string? Umowa
        {
            get => umowa;
            set { umowa = value; }
        }
        public MainModel()
        {
            workerBuilderTmp = new WorkerBuilder();
        }
    }
}
