﻿using Backend.Models;
using Backend.TableDataGateways.StorageContexts;
using Backend.TableModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DesktopClient.ViewModels
{
    public class LesniHospodarskaEvidenceViewModel : BaseViewModel
    {
        private IStorageContext db;
        LesniHospodarskaEvidenceTableModule lheTableModule;
        LesniHospodarskyCelekTableModule lhcTableModule;
        OddeleniTableModule oddTableModule;
        DilecTableModule dilTableModule;
        PorostTableModule porTableModule;
        PorostniSkupinaTableModule pskTableModule;

        public ICommand FilterCommand { get; set; }
        public ICommand AddLheCommand { get; set; }
        public ICommand EditLheCommand { get; set; }
        public ICommand RemoveLheCommand { get; set; }
        public ICommand UpdateLheCommand { get; set; }
        public ICommand CloseCommand { get; set; }

        private List<LesniHospodarskyCelek> _lhcList;
        public List<LesniHospodarskyCelek> LhcList { get { return _lhcList; } set { _lhcList = value; OnPropertyChanged("LhcList"); } }

        private LesniHospodarskyCelek _lhcListSelected;
        public LesniHospodarskyCelek LhcListSelected { get { return _lhcListSelected; } set { _lhcListSelected = value; OnPropertyChanged("LhcListSelected"); OddList = oddTableModule.LoadOddeleni(value); } }

        private List<Oddeleni> _oddList;
        public List<Oddeleni> OddList { get { return _oddList; } set { _oddList = value; OnPropertyChanged("OddList"); } }

        private Oddeleni _oddListSelected;
        public Oddeleni OddListSelected { get { return _oddListSelected; } set { _oddListSelected = value; OnPropertyChanged("OddListSelected"); DilList = dilTableModule.LoadDilce(value); } }

        private List<Dilec> _dilList;
        public List<Dilec> DilList { get { return _dilList; } set { _dilList = value; OnPropertyChanged("DilList"); } }

        private Dilec _dilListSelected;
        public Dilec DilListSelected { get { return _dilListSelected; } set { _dilListSelected = value; OnPropertyChanged("DilListSelected"); PorList = porTableModule.LoadPorosty(value); } }

        private List<Porost> _porList;
        public List<Porost> PorList { get { return _porList; } set { _porList = value; OnPropertyChanged("PorList"); } }

        private Porost _porListSelected;
        public Porost PorListSelected { get { return _porListSelected; } set { _porListSelected = value; OnPropertyChanged("PorListSelected"); PskList = pskTableModule.LoadPorostniSkupiny(value); } }

        private List<PorostniSkupina> _pskList;
        public List<PorostniSkupina> PskList { get { return _pskList; } set { _pskList = value; OnPropertyChanged("PskList"); } }

        private PorostniSkupina _pskListSelected;
        public PorostniSkupina PskListSelected { get { return _pskListSelected; } set { _pskListSelected = value; OnPropertyChanged("PskListSelected"); LheList = lheTableModule.LoadLhe(value); } }

        private List<LesniHospodarskaEvidence> _lheList;
        public List<LesniHospodarskaEvidence> LheList { get { return _lheList; } set { _lheList = value; OnPropertyChanged("LheList"); }  }

        private string _numberOfEntries;
        public string NumberOfEntries { get { return _numberOfEntries; } set { _numberOfEntries = value; OnPropertyChanged("NumberOfEntries"); } }

        public LesniHospodarskaEvidenceViewModel(IStorageContext db, Uzivatel uzivatel)
        {
            this.db = db;
            lheTableModule = new LesniHospodarskaEvidenceTableModule(db);
            lhcTableModule = new LesniHospodarskyCelekTableModule(db);
            oddTableModule = new OddeleniTableModule(db);
            dilTableModule = new DilecTableModule(db);
            porTableModule = new PorostTableModule(db);
            pskTableModule = new PorostniSkupinaTableModule(db);

            LhcList = lhcTableModule.LoadLhc(uzivatel);
        }
    }
}
