using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServiceExamen
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]List<clientes>listaClientes();
        [OperationContract]List<paises>listaPaises();
        [OperationContract]string AgregarCliente(clientes reg);
        [OperationContract]string EliminarCliente(string id);
        // TODO: agregue aquí sus operaciones de servicio
    }


    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    [DataContract]
    public class clientes
    {
       [DataMember]public string idcliente { get; set; }
         
        [DataMember]public string nombrecia { get; set; }
        [DataMember]public string direccion { get; set; }
        [DataMember]public string idpais { get; set; }
        [DataMember]public string nombrepais { get; set; }

        [DataMember]public string telefono { get; set; }

    }
    [DataContract]
    public class paises
    {
        [DataMember]public 
        string idpais { get; set; }

        [DataMember]public 
        string nombrepais { get; set; }

    }
}
