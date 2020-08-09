using DnDLibrary.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace DnDPlayerSheet.Models
{
    public struct ClassLevel
    {
        public Role Class { get; set; }

        public int Level { get; set; }
    }

    public class Character : INotifyPropertyChanged
    {
        private int tempStr = 0;
        private int tempDex = 0;
        private int tempCon = 0;
        private int tempInt = 0;
        private int tempWis = 0;
        private int tempCha = 0;
        private int fortitude;
        private int reflex;
        private int will;

        public string Name { get; set; }

        public List<ClassLevel> Classes { get; set; }

        public Alignment Alignment { get; set; }

        public int MaxPW { get; set; }

        public int CurrentPW { get; set; }

        public int KP { get; set; }

        public int Touch { get; set; }

        public int Unprepared { get; set; }

        public int Speed { get; set; }

        public string Race { get; set; }

        public string MainNotes { get; set; }

        public int Strength { get; set; }

        public int Dexterity { get; set; }

        public int Constitution { get; set; }

        public int Intelligence { get; set; }

        public int Wisdom { get; set; }

        public int Charisma { get; set; }

        public int TempStr
        {
            get => tempStr;
            set
            {
                tempStr = value;
                OnPropertyChanged("TempStr");
            }
        }
        public int TempDex
        {
            get => tempDex;
            set
            {
                tempDex = value;
                OnPropertyChanged("TempDex");
            }
        }
        public int TempCon
        {
            get => tempCon; set
            {
                tempCon = value;
                OnPropertyChanged("TempCon");
            }
        }
        public int TempInt
        {
            get => tempInt; set
            {
                tempInt = value;
                OnPropertyChanged("TempInt");
            }
        }
        public int TempWis
        {
            get => tempWis; set
            {
                tempWis = value;
                OnPropertyChanged("TempWis");
            }
        }
        public int TempCha
        {
            get => tempCha; set
            {
                tempCha = value;
                OnPropertyChanged("TempCha");
            }
        }
        public int Fortitude
        {
            get => fortitude; set
            {
                fortitude = value;
                OnPropertyChanged("Fortitude");
            }
        }

        public int Reflex
        {
            get => reflex; set
            {
                reflex = value;
                OnPropertyChanged("Reflex");
            }
        }

        public int Will
        {
            get => will; set
            {
                will = value;
                OnPropertyChanged("Will");
            }
        }

        public int BaseAttackBonus { get; set; }

        public int Initiative { get; set; }

        public int Grapple { get; set; }

        public List<int> SpellIds { get; set; }

        [JsonIgnore]
        public ObservableCollection<Spell> Spells { get; set; } = new ObservableCollection<Spell>();

        public List<int> SkillPoints { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
