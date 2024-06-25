using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCF_GCCCine.Clases;

namespace WCF_GCCCine
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IPelicula
    {
      //  [OperationContract]
      /*Esta linea permite realizar un test de conexion */
      //  string TestConnection();

        [OperationContract]
        List<Pelicula> GetPeliculas();

        [OperationContract]
        Pelicula GetPelicula(int PeliculaId);

        [OperationContract]
        void AddPelicula(Pelicula pelicula);

        //---------------------------------------Funciones--------------------------------//
        [OperationContract]
        List<Funciones> GetFunciones();

        [OperationContract]
        void addFunciones(Funciones funciones);


    }
}