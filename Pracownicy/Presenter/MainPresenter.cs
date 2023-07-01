using Pracownicy.Model;
using Pracownicy.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pracownicy.Presenter
{
    class MainPresenter
    {
        private View.Form1 _view;
        private Model.MainModel _model;
        private string worker;

        public MainPresenter(View.Form1 view, Model.MainModel model)
        {
            _view = view;
            _model = model;
            _view.AddUser += _view_AddUser;
            _view.TextBox1TextChanged += _view_TextBox1TextChanged;
            _view.TextBox2TextChanged += _view_TextBox2TextChanged;
            _view.DateTimePickerChanged += _view_DateTimePickerChanged;
            _view.NumericUpDownChanged += _view_NumericUpDownChanged;
            _view.ComboBoxChanged += _view_ComboBoxChanged;
            _view.RadioButtonChanged += _view_RadioButtonChanged;
            _view.LoadSelectedData += _view_LoadSelectedData;
            _view.Serialization += _view_Serialization;
            _view.Deserialization += _view_Deserialization;
        }


        private void add()
        {
            _model.Imie = _model.WorkerBuilderTmp.WorkerName;
            _model.Nazwisko = _model.WorkerBuilderTmp.WorkerLastname;
            _model.Data = _model.WorkerBuilderTmp.WorkerDate;
            _model.Pensja = _model.WorkerBuilderTmp.WorkerSalary;
            _model.Stanowisko = _model.WorkerBuilderTmp.WorkerPosition;
            _model.Umowa = _model.WorkerBuilderTmp.WorkerContract;
            if(_model.Imie != null && _model.Nazwisko != null && _model.Data != null && _model.Pensja != null && _model.Stanowisko != null && _model.Umowa != null)
                worker = Model.Operations.Add((string)_model.Imie, (string)_model.Nazwisko, (string)_model.Data, (string)_model.Pensja, (string)_model.Stanowisko, (string)_model.Umowa);
        }
        private void _view_AddUser()
        {
           add();
            if (worker != null)
            {
                _model.WorkerBuilderTmp = new Model.WorkerBuilder(worker);
                UpdateView();
            }
        }
        private void _view_TextBox1TextChanged(string text)
        {
            _model.WorkerBuilderTmp.NameChange(text);
        }
        private void _view_TextBox2TextChanged(string text)
        {
            _model.WorkerBuilderTmp.LastnameChange(text);
        }
        private void _view_DateTimePickerChanged(string text)
        {
            _model.WorkerBuilderTmp.DateChange(text);
        }
        private void _view_NumericUpDownChanged(string text)
        {
            _model.WorkerBuilderTmp.NumericUpDownChange(text);
        }
        private void _view_ComboBoxChanged(string text)
        {
            _model.WorkerBuilderTmp.ComboBoxChange(text);
        }
        private void _view_RadioButtonChanged(string text)
        {
            _model.WorkerBuilderTmp.RadioButtonChange(text);
        }
        private void _view_LoadSelectedData(string selectedItem)
        {
            _model.WorkerBuilderTmp = new Model.WorkerBuilder(_view);
            _model.WorkerBuilderTmp.LoadData(selectedItem);
        }
        private void _view_Serialization()
        {
            _model.WorkerBuilderTmp = new Model.WorkerBuilder(_view);
            _model.WorkerBuilderTmp.Serialization();
        }
        private void _view_Deserialization()
        {
            _model.WorkerBuilderTmp = new Model.WorkerBuilder(_view);
            _model.WorkerBuilderTmp.Deserialization();
        }
        private void UpdateView() => _view.DisplayText = _model.WorkerBuilderTmp.WorkerText; 
    }
}
