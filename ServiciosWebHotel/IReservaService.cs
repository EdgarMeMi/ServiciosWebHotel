using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiciosWebHotel
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IReservaService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IReservaService
    {
        [OperationContract]
        bool AgregarReserva(Reserva2 nuevaReserva);
    }
    [DataContract]
    public class Reserva2
    {
        [DataMember]
        public string Cliente { get; set; }

        [DataMember]
        public string HabTipo { get; set; }

        [DataMember]
        public double PrecioNoche { get; set; }

        [DataMember]
        public int Noches { get; set; }

        [DataMember]
        public DateTime Checkin { get; set; }

        [DataMember]
        public DateTime Checkout { get; set; }
    }
}
