using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecteurAudio.ViewModel
{
    /// <summary>
    /// Model View de la musique dans au niveau du lecteur
    /// </summary>
    public class LecteurMusiqueViewModel //: INotifyPropertyChanged
    {
        public int Ordre { get; set; }
        public string Titre { get; set; }
        public string Artiste { get; set; }
        public string Path { get; set; }
        public double Duree { get; set; }

        /*public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged(string Obj)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(Obj));
            }
        }*/
    }
}
