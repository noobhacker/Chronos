using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ChronosWebAPI.Models
{
    public class Happening/* : INotifyPropertyChanged*/
    {
        #region server side entity
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public double Price { get; set; }
        public string Location { get; set; }
        public int LocationX { get; set; }
        public int LocationY { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string Contact { get; set; }
        public string FbUrl { get; set; }
        #endregion
        public string Organizer { get; set; }

        //public event PropertyChangedEventHandler PropertyChanged;
        //protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}

        //private string id;
        //public string Id
        //{
        //    get
        //    {
        //        return id;
        //    }

        //    set
        //    {
        //        id = value;
        //        OnPropertyChanged();
        //    }
        //}

        //private string name;
        //public string Name
        //{
        //    get
        //    {
        //        return name;
        //    }

        //    set
        //    {
        //        name = value;
        //        OnPropertyChanged();
        //    }
        //}

        //private DateTime startDateTime;
        //public DateTime StartDateTime
        //{
        //    get
        //    {
        //        return startDateTime;
        //    }

        //    set
        //    {
        //        startDateTime = value;
        //        OnPropertyChanged();
        //    }
        //}

        //private DateTime endDateTime;
        //public DateTime EndDateTime
        //{
        //    get
        //    {
        //        return endDateTime;
        //    }

        //    set
        //    {
        //        endDateTime = value;
        //        OnPropertyChanged();
        //    }
        //}

        //private double price;
        //public double Price
        //{
        //    get
        //    {
        //        return price;
        //    }

        //    set
        //    {
        //        price = value;
        //        OnPropertyChanged();
        //    }
        //}

        //private string location;
        //public string Location
        //{
        //    get
        //    {
        //        return location;
        //    }

        //    set
        //    {
        //        location = value;
        //        OnPropertyChanged();
        //    }
        //}

        //private int locationX;
        //public int LocationX
        //{
        //    get
        //    {
        //        return locationX;
        //    }

        //    set
        //    {
        //        locationX = value;
        //        OnPropertyChanged();
        //    }
        //}

        //private int locationY;
        //public int LocationY
        //{
        //    get
        //    {
        //        return locationY;
        //    }

        //    set
        //    {
        //        locationY = value;
        //        OnPropertyChanged();
        //    }
        //}

        //private string imageUrl;
        //public string ImageUrl
        //{
        //    get
        //    {
        //        return imageUrl;
        //    }

        //    set
        //    {
        //        imageUrl = value;
        //        OnPropertyChanged();
        //    }
        //}

        //private string description;
        //public string Description
        //{
        //    get
        //    {
        //        return description;
        //    }

        //    set
        //    {
        //        description = value;
        //        OnPropertyChanged();
        //    }
        //}

        //private string contact;
        //public string Contact
        //{
        //    get
        //    {
        //        return contact;
        //    }

        //    set
        //    {
        //        contact = value;
        //        OnPropertyChanged();
        //    }
        //}

        //private string fbUrl;
        //public string FbUrl
        //{
        //    get
        //    {
        //        return fbUrl;
        //    }

        //    set
        //    {
        //        fbUrl = value;
        //        OnPropertyChanged();
        //    }
        //}

    }
}
