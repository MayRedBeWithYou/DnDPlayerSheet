using DnDLibrary.Models;
using DnDPlayerSheet.Controllers;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDPlayerSheet.Models
{
    public class ClassLevel : INotifyPropertyChanged
    {
        private int level;
        private Role role;

        public Role Class
        {
            get => role;
            set
            {
                role = value;
                OnPropertyChanged("Role");
            }
        }

        public int Level
        {
            get => level;
            set
            {
                level = value;
                OnPropertyChanged("Level");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
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
        private int currentPW;
        private int tempFort;
        private int tempRefl;
        private int tempWill;
        private ObservableCollection<int> spellIds;
        private Alignment alignment;
        private int maxPW;
        private int kP;
        private int touch;
        private int unprepared;
        private int speed;
        private string race;
        private int strength;
        private string mainNotes;
        private int dexterity;
        private int constitution;
        private int intelligence;
        private int wisdom;
        private int charisma;
        private string name;
        private int baseAttackBonus;
        private int initiative;
        private int grapple;

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public ObservableCollection<ClassLevel> Classes { get; set; }

        public Alignment Alignment
        {
            get => alignment;
            set
            {
                alignment = value;
                OnPropertyChanged("Alignment");
            }
        }

        public int MaxPW
        {
            get => maxPW;
            set
            {
                maxPW = value;
                OnPropertyChanged("MaxPW");
            }
        }

        public int CurrentPW
        {
            get => currentPW;
            set
            {
                currentPW = value;
                OnPropertyChanged("CurrentPW");
            }
        }

        public int KP
        {
            get => kP;
            set
            {
                kP = value;
                OnPropertyChanged("KP");
            }
        }

        public int Touch
        {
            get => touch;
            set
            {
                touch = value;
                OnPropertyChanged("Touch");
            }
        }

        public int Unprepared
        {
            get => unprepared;
            set
            {
                unprepared = value;
                OnPropertyChanged("Unprepared");
            }
        }

        public int Speed
        {
            get => speed;
            set
            {
                speed = value;
                OnPropertyChanged("Speed");
            }
        }

        public string Race
        {
            get => race;
            set
            {
                race = value;
                OnPropertyChanged("Race");
            }
        }

        public string MainNotes
        {
            get => mainNotes;
            set
            {
                mainNotes = value;
                OnPropertyChanged("MainNotes");
            }
        }

        public int Strength
        {
            get => strength;
            set
            {
                strength = value;
                OnPropertyChanged("Strength");
            }
        }

        public int Dexterity
        {
            get => dexterity;
            set
            {
                dexterity = value;
                OnPropertyChanged("Dexterity");
            }
        }

        public int Constitution
        {
            get => constitution;
            set
            {
                constitution = value;
                OnPropertyChanged("Constitution");
            }
        }

        public int Intelligence
        {
            get => intelligence;
            set
            {
                intelligence = value;
                OnPropertyChanged("Intelligence");
            }
        }

        public int Wisdom
        {
            get => wisdom;
            set
            {
                wisdom = value;
                OnPropertyChanged("Wisdom");
            }
        }

        public int Charisma
        {
            get => charisma;
            set
            {
                charisma = value;
                OnPropertyChanged("Charisma");
            }
        }

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
            get => tempCon;
            set
            {
                tempCon = value;
                OnPropertyChanged("TempCon");
            }
        }
        public int TempInt
        {
            get => tempInt;
            set
            {
                tempInt = value;
                OnPropertyChanged("TempInt");
            }
        }
        public int TempWis
        {
            get => tempWis;
            set
            {
                tempWis = value;
                OnPropertyChanged("TempWis");
            }
        }
        public int TempCha
        {
            get => tempCha;
            set
            {
                tempCha = value;
                OnPropertyChanged("TempCha");
            }
        }
        public int Fortitude
        {
            get => fortitude;
            set
            {
                fortitude = value;
                OnPropertyChanged("Fortitude");
            }
        }

        public int Reflex
        {
            get => reflex;
            set
            {
                reflex = value;
                OnPropertyChanged("Reflex");
            }
        }

        public int Will
        {
            get => will;
            set
            {
                will = value;
                OnPropertyChanged("Will");
            }
        }

        public int TempFort
        {
            get => tempFort;
            set
            {
                tempFort = value;
                OnPropertyChanged("TempFort");
            }
        }

        public int TempRefl
        {
            get => tempRefl;
            set
            {
                tempRefl = value;
                OnPropertyChanged("TempRefl");
            }
        }

        public int TempWill
        {
            get => tempWill;
            set
            {
                tempWill = value;
                OnPropertyChanged("TempWill");
            }
        }

        public int BaseAttackBonus
        {
            get => baseAttackBonus;
            set
            {
                baseAttackBonus = value;
                OnPropertyChanged("BaseAttackBonus");
            }
        }

        public int Initiative
        {
            get => initiative;
            set
            {
                initiative = value;
                OnPropertyChanged("Initiative");
            }
        }

        public int Grapple
        {
            get => grapple;
            set
            {
                grapple = value;
                OnPropertyChanged("Grapple");
            }
        }

        public ObservableCollection<int> SpellIds
        {
            get => spellIds;
            set
            {
                spellIds = value;
            }
        }

        [JsonIgnore]
        public ObservableCollection<Spell> Spells { get; set; } = new ObservableCollection<Spell>();

        public List<int> SkillPoints { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            this.SaveToFile();
        }

        public async Task RestoreSpellsAsync()
        {
            if (SpellIds is null || SpellIds.Count == 0) return;
            Spell[] spells = await Task.WhenAll(SpellIds.Select(async id => await App.DataProvider.GetSpellAsync(id)))
                                       .ConfigureAwait(false);
            Spells = new ObservableCollection<Spell>(spells.OrderBy(x => x.Tier).ThenBy(x => x.Name));
        }

        public void AddSpell(Spell spell)
        {
            SpellIds.Add(spell.Id);
            Spells.Add(spell);
            this.SaveToFile();
        }

        public void RemoveSpell(Spell spell)
        {
            SpellIds.Remove(spell.Id);
            Spells.Remove(spell);
            this.SaveToFile();
        }
    }
}
