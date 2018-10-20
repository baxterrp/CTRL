using CTRL_Core.Backbone.Enums;

namespace CTRL_Core.Backbone.Classes
{
    public class Address
    {
        public string AddressLineOne { get; set; }

        public string AddressLineTwo { get; set; }

        public string City { get; set; }

        public State State { get; set; }

        public string Zip { get; set; }
    }
}
