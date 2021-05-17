﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DemoTDD
{
    public class ViewModel : INotifyPropertyChanged
    {
        public ICommand Add1EuroCommand { get; set; }
        public ICommand Add2EuroCommand { get; set; }
        public ICommand Add50CentCommand { get; set; }
        public ICommand Add20CentCommand { get; set; }
        public ICommand Add10CentCommand { get; set; }
        public ICommand RefundCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private double budget { get; set; }
        public double Budget { get => budget;
            set {
                budget = value;
                if(PropertyChanged!= null) { 
                    PropertyChanged(this, new PropertyChangedEventArgs("Budget"));
                }
            }
        }

        public List<Slot> Slots { get; set; }

        private ISlotDataRepository slotRepository;

        public ViewModel(ISlotDataRepository slotRepository)
        {
            Add1EuroCommand = new RelayCommand(Add1Euro);
            Add2EuroCommand = new RelayCommand(Add2Euro);
            Add50CentCommand = new RelayCommand(Add50Cent);
            Add20CentCommand = new RelayCommand(Add20Cent);
            Add10CentCommand = new RelayCommand(Add10Cent);
            RefundCommand = new RelayCommand(Refund);

            this.slotRepository = slotRepository;
            if (slotRepository != null) { 
                Slots = slotRepository.LoadData();
            }

            if (Slots == null) { 
                Slots = new List<Slot>();
            }
        }

        public void Refund()
        {
            Budget = 0;
        }

        public void Add1Euro()
        {
            Budget += 1;
        }

        public void Add2Euro()
        {
            Budget += 2;
        }

        public void Add50Cent()
        {
            Budget += 0.5;
        }


        public void Add20Cent()
        {
            Budget += 0.2;
        }


        public void Add10Cent()
        {
            Budget += 0.1;
        }
    }
}
