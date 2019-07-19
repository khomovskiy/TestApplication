using System;

namespace TestApplication
{
    //Модель данных загружаемых с БД и отображаемых в списке
    class DataModel
    {
        public int Id { get; set; }
        public int CoordId { get; set; }
        public string BoardName { get; set; }
        public string GovernmentNumber { get; set; }
        public DateTime LastUpdateDateTime { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
