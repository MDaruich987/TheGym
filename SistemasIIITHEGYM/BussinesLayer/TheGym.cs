using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Web;


namespace SistemasIIITHEGYM.BussinesLayer
{
    public class TheGym
    {
        //POR FAVOR, COMENTAR TODO.
        //variables para realizar el registro de sucursal
        public string NombreSucursal;
        public string DireccionSucursal;
        public long TelefonoSucursal;
        //variable para realizar la busqueda de cliente
        public string NombreClienteBusc;
        public string DNIClienteBusc = "0";
        //variables para realizar la consulta de empleado
        public string NombreEmpleadoBusc;
        public string DNIEmpleadoBusc = "";
        public string IDEmpleadoBusc = "0";
        public string CargoEmpleadoBusc = "";
        //variables para realizar registro de empleado
        public string NombreEmpladoIns;
        public string ApellidoEmpleadoIns;
        public string FechaNacEmpleadoIns;
        public string EmailEmpleadoIns;
        public string TelefEmpleadoIns;
        public string DocumentoEmpleadoIns;
        public string FechaContEmpleadoIns;
        public string FotoEmpleadoIns;
        public string TitulEmpleadoIns;
        public string FKCargoEmpleadoIns;
        public string FKTipoDocEmpleadoIns;
        public string FKSucursalEmpleadoIns;
        public string CalleEmpleadoIns;
        public string BarrioEmpleadoIns;
        public string NumeroEmpleadoIns;
        public string FKLocalidadEmpleadoIns;
        //variables para realizar la edicion de empleado
        public string DNIEditar = "0";
        public string NombreClienteEditar;
        public string ApellidoClienteEditar;
        public string TelefonoClienteEditar;
        public string CalleClienteEditar;
        public string NumeroClienteEditar;
        public string BarrioClienteEditar;
        public string FKLocalidadClienteEditar;
        public string FKTipoDocClienteEditar;
        public string FechaClienteEditar;
        public string EmailClienteEditar;
        public string DNIClienteEditar;
        //variables para consultar una actividad
        public string NombreActividadBuscar;
        //variables para consultar cliente
        public string NombreClienteBuscar;
        //variables para registrar actividad
        public string NombreActividad;
        public string ProfesorActividad;
        public string SucursalActividad;
        public string HorarioInicioActividad;
        public string HorarioFinActividad;
        public string CuposActividad;
        public string DescripcionActividad;
        // variables para registrar cliente
        public string NombreCliente;
        public string ApellidoCliente;
        public string FechaCliente;
        public string EmailCliente;
        public string TelefonoCliente;
        public string CalleCliente;
        public string NumeroCliente;
        public string BarrioCliente;
        public string FKLocalidadCliente;
        public string DNICliente;
        public string FotoCliente;
        public string FKTipoDocumento;
        //Variables para Registrar Horario de Instructor
        public string FKEmpleadoReg;
        public string FKActividadReg;
        public string FKSemanaReg;
        public string DesdeReg;
        public string HastaReg;
        //Variable para buscar ID det pla
        public string FechaIdDetCaja;
        //variables para registrar movimiento de caja
        public string FKFormaPagoMov;
        public string FKDetCajaMov;
        public string MontoMov;
        public string EstadoMov;
        public string ConceptoMov;
        public string ComprobanteMov;
        public string HoraMov;
        //Variable para registrar Cuota
        public string FK_planCuota;
        public string MontoCuota;
        public string FechaCuota;
        public string VencimientoCuota;
        public string FK_clienteCuota;
        // varialbe para calcular vencimiento
        public string IDPlanVencimiento;
        //varaible para buscar monto de plan
        public string IdPlanMonto;
        //Variable para obtener todos los datos de Cliente
        public string IdClienteSearch;
        //Variable para editar Empleados
        public string NombreEmpladoEdit;
        public string ApellidoEmpleadoEdit;
        public string FechaNacEmpleadoEdit;
        public string EmailEmpleadoEdit;
        public string TelefEmpleadoEdit;
        public string DocumentoEmpleadoEdit;
        public string FechaContEmpleadoEdit;
        public string TitulEmpleadoEdit;
        public string FKCargoEmpleadoEdit;
        public string FKTipoDocEmpleadoEdit;
        public string FKSucursalEmpleadoEdit;
        public string CalleEmpleadoEdit;
        public string BarrioEmpleadoEdit;
        public string NumeroEmpleadoEdit;
        public string FKLocalidadEmpleadoEdit;




        //métodos
        //método para agregar una nueva sucursal


        public void UpdateEmpleado()
        {
            SqlParameter[] parameters = new SqlParameter[15];
            parameters[0] = BussinesDataLayer.DataAccess.AddParameter("@Nombre", NombreEmpladoEdit, SqlDbType.NVarChar, 50);
            parameters[1] = BussinesDataLayer.DataAccess.AddParameter("@Apellido", ApellidoEmpleadoEdit, SqlDbType.NVarChar, 50);
            parameters[2] = BussinesDataLayer.DataAccess.AddParameter("@Fecha_nac", FechaNacEmpleadoEdit, SqlDbType.Date, 50);
            parameters[3] = BussinesDataLayer.DataAccess.AddParameter("@Email", EmailEmpleadoEdit, SqlDbType.NVarChar, 100);
            parameters[4] = BussinesDataLayer.DataAccess.AddParameter("@Telefono", TelefEmpleadoEdit, SqlDbType.BigInt, 50);
            parameters[5] = BussinesDataLayer.DataAccess.AddParameter("@Titulo", TitulEmpleadoEdit, SqlDbType.NVarChar, 50);
            parameters[6] = BussinesDataLayer.DataAccess.AddParameter("@FK_cargo", FKCargoEmpleadoEdit, SqlDbType.Int, 50);
            parameters[7] = BussinesDataLayer.DataAccess.AddParameter("@FK_TipoDocumento", FKTipoDocEmpleadoEdit, SqlDbType.Int, 50);
            parameters[8] = BussinesDataLayer.DataAccess.AddParameter("@Documento", DocumentoEmpleadoEdit, SqlDbType.NVarChar, 20);
            parameters[9] = BussinesDataLayer.DataAccess.AddParameter("@Calle", CalleEmpleadoEdit, SqlDbType.NVarChar, 50);
            parameters[10] = BussinesDataLayer.DataAccess.AddParameter("@Barrio", BarrioEmpleadoEdit, SqlDbType.NVarChar, 50);
            parameters[11] = BussinesDataLayer.DataAccess.AddParameter("@Numero", NumeroEmpleadoEdit, SqlDbType.Int, 50);
            parameters[12] = BussinesDataLayer.DataAccess.AddParameter("@FK_localidad", FKLocalidadEmpleadoEdit, SqlDbType.Int, 50);
            parameters[13] = BussinesDataLayer.DataAccess.AddParameter("@Fecha_cont", FechaContEmpleadoEdit, SqlDbType.Date, 50);
            parameters[14] = BussinesDataLayer.DataAccess.AddParameter("@DNIedit", DNIEditar, SqlDbType.NVarChar, 50);
            DataTable dt = BussinesDataLayer.DataAccess.ExcecuteDTbyProcedure("PA_UpdateEmpleado", parameters);

        }



        public void AddCronograma()
        {
            SqlParameter[] parameters = new SqlParameter[5];
            parameters[0] = BussinesDataLayer.DataAccess.AddParameter("@FK_semana", FKSemanaReg, SqlDbType.Int, 50);
            parameters[1] = BussinesDataLayer.DataAccess.AddParameter("@FK_empleado",FKEmpleadoReg, SqlDbType.Int, 50);
            parameters[2] = BussinesDataLayer.DataAccess.AddParameter("@FK_actividad", FKActividadReg, SqlDbType.Int, 50);
            parameters[3] = BussinesDataLayer.DataAccess.AddParameter("@Desde", DesdeReg, SqlDbType.Time, 50);
            parameters[4] = BussinesDataLayer.DataAccess.AddParameter("@Hasta", HastaReg, SqlDbType.Time, 50);
            DataTable dt = BussinesDataLayer.DataAccess.ExcecuteDTbyProcedure("PA_AddCronograma", parameters);
        }

        public DataTable GetEstadoDetCaja()
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = BussinesDataLayer.DataAccess.AddParameter("@Fecha", FechaIdDetCaja, SqlDbType.Date, 50);
            DataTable dt = BussinesDataLayer.DataAccess.ExcecuteDTbyProcedure("PA_GetEstadoDetCaja", parameters);
            return dt;
        }

        public void AddMovimientoCaja()
        {
            SqlParameter[] parameters = new SqlParameter[7];
            parameters[0] = BussinesDataLayer.DataAccess.AddParameter("@FK_formapago", FKFormaPagoMov, SqlDbType.Int, 50);
            parameters[1] = BussinesDataLayer.DataAccess.AddParameter("@Monto", MontoMov, SqlDbType.Money, 50);
            parameters[2] = BussinesDataLayer.DataAccess.AddParameter("@Estado", EstadoMov, SqlDbType.NVarChar, 20);
            parameters[3] = BussinesDataLayer.DataAccess.AddParameter("@Concepto", ConceptoMov, SqlDbType.NVarChar, 100);
            parameters[4] = BussinesDataLayer.DataAccess.AddParameter("@Comprobante", ComprobanteMov, SqlDbType.NVarChar, 50);
            parameters[5] = BussinesDataLayer.DataAccess.AddParameter("@FK_DetCaja", FKDetCajaMov, SqlDbType.Int, 50);
            parameters[6] = BussinesDataLayer.DataAccess.AddParameter("@Hora", HoraMov, SqlDbType.Time, 50);
            DataTable dt = BussinesDataLayer.DataAccess.ExcecuteDTbyProcedure("PA_AddMovCaja", parameters);
        }

        public DataTable GetEstadoDetCajaAP()
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = BussinesDataLayer.DataAccess.AddParameter("@Fecha", FechaIdDetCaja, SqlDbType.Date, 50);
            DataTable dt = BussinesDataLayer.DataAccess.ExcecuteDTbyProcedure("PA_GetEstadoDetCajaAP", parameters);
            return dt;
        }

        public DataTable GetIdDetCaja()
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = BussinesDataLayer.DataAccess.AddParameter("@Fecha", FechaIdDetCaja, SqlDbType.Date, 50);
            DataTable dt = BussinesDataLayer.DataAccess.ExcecuteDTbyProcedure("PA_GetIdDetCaja", parameters);
            return dt;
        }


        public void AddNewSucursal()
        {
            SqlParameter[] parameters = new SqlParameter[3];
            parameters[0] = BussinesDataLayer.DataAccess.AddParameter("@Nombre", NombreSucursal, SqlDbType.VarChar, 50);
            parameters[1] = BussinesDataLayer.DataAccess.AddParameter("@Direccion", DireccionSucursal, SqlDbType.VarChar, 50);
            parameters[2] = BussinesDataLayer.DataAccess.AddParameter("@Telefono", TelefonoSucursal, SqlDbType.BigInt, 100);
            DataTable dt = BussinesDataLayer.DataAccess.ExcecuteDTbyProcedure("PA_AddSucursal", parameters);
        }

        public DataTable GetAllLocalidades()
        {
            SqlParameter[] parameters = new SqlParameter[0];
            DataTable dt = BussinesDataLayer.DataAccess.ExcecuteDTbyProcedure("PA_GetAllLocalidades", parameters);
            return dt;
        }

        public DataTable GetAllTipoDocumento()
        {
            SqlParameter[] parameters = new SqlParameter[0];
            DataTable dt = BussinesDataLayer.DataAccess.ExcecuteDTbyProcedure("PA_GetAllTipoDocumento", parameters);
            return dt;
        }
        public void AddNewEmpleado()
        {
            SqlParameter[] parameters = new SqlParameter[16];
            parameters[0] = BussinesDataLayer.DataAccess.AddParameter("@Nombre", NombreEmpladoIns, SqlDbType.NVarChar, 50);
            parameters[1] = BussinesDataLayer.DataAccess.AddParameter("@Apellido", ApellidoEmpleadoIns, SqlDbType.NVarChar, 50);
            parameters[2] = BussinesDataLayer.DataAccess.AddParameter("@Fecha_nac", FechaNacEmpleadoIns, SqlDbType.Date, 20);
            parameters[3] = BussinesDataLayer.DataAccess.AddParameter("@Email", EmailEmpleadoIns, SqlDbType.NVarChar, 100);
            parameters[4] = BussinesDataLayer.DataAccess.AddParameter("@Telefono", TelefEmpleadoIns, SqlDbType.BigInt, 50);
            parameters[5] = BussinesDataLayer.DataAccess.AddParameter("@Calle", CalleEmpleadoIns, SqlDbType.NVarChar, 50);
            parameters[6] = BussinesDataLayer.DataAccess.AddParameter("@Numero", NumeroEmpleadoIns, SqlDbType.Int, 50);
            parameters[7] = BussinesDataLayer.DataAccess.AddParameter("@Barrio", BarrioEmpleadoIns, SqlDbType.NVarChar, 50);
            parameters[8] = BussinesDataLayer.DataAccess.AddParameter("@DNI", DocumentoEmpleadoIns, SqlDbType.NVarChar, 20);
            parameters[9] = BussinesDataLayer.DataAccess.AddParameter("@FK_TipoDocumento", FKTipoDocEmpleadoIns, SqlDbType.Int, 50);
            parameters[10] = BussinesDataLayer.DataAccess.AddParameter("@Fecha_cont", FechaContEmpleadoIns, SqlDbType.Date, 100);
            parameters[11] = BussinesDataLayer.DataAccess.AddParameter("@Titulo", TitulEmpleadoIns, SqlDbType.NVarChar, 50);
            parameters[12] = BussinesDataLayer.DataAccess.AddParameter("@FK_cargo", FKCargoEmpleadoIns, SqlDbType.Int, 50);
            parameters[13] = BussinesDataLayer.DataAccess.AddParameter("@Foto", FotoEmpleadoIns, SqlDbType.NVarChar, 500);
            parameters[14] = BussinesDataLayer.DataAccess.AddParameter("@FK_sucursal", FKSucursalEmpleadoIns, SqlDbType.Int, 50);
            parameters[15] = BussinesDataLayer.DataAccess.AddParameter("@FK_localidad", FKLocalidadEmpleadoIns, SqlDbType.Int, 50);
            DataTable dt = BussinesDataLayer.DataAccess.ExcecuteDTbyProcedure("PA_AddEmpleado", parameters);
        }

            //método para agregar una nueva actividad

            public void AddNewActividad()
            {
                SqlParameter[] parameters = new SqlParameter[7];
                parameters[0] = BussinesDataLayer.DataAccess.AddParameter("@Nombre", NombreActividad, SqlDbType.VarChar, 50);
                parameters[1] = BussinesDataLayer.DataAccess.AddParameter("@Profesor", ProfesorActividad, SqlDbType.Int, 50);
                parameters[2] = BussinesDataLayer.DataAccess.AddParameter("@Sucursal", SucursalActividad, SqlDbType.Int, 50);
                parameters[3] = BussinesDataLayer.DataAccess.AddParameter("@Cupos", CuposActividad, SqlDbType.Int, 50);
                parameters[4] = BussinesDataLayer.DataAccess.AddParameter("@Hora_inicio", HorarioInicioActividad, SqlDbType.Time, 50);
                parameters[5] = BussinesDataLayer.DataAccess.AddParameter("@Hora_fin", HorarioFinActividad, SqlDbType.Time, 50);
                parameters[6] = BussinesDataLayer.DataAccess.AddParameter("@Descripcion", DescripcionActividad, SqlDbType.VarChar, 50);
                DataTable dt = BussinesDataLayer.DataAccess.ExcecuteDTbyProcedure("PA_AddActividad", parameters);
            }


            //método para consultar un cliente
            public DataTable GetClienteNom()
            {
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = BussinesDataLayer.DataAccess.AddParameter("@Nombre", NombreClienteBusc, SqlDbType.VarChar, 50);
                parameters[1] = BussinesDataLayer.DataAccess.AddParameter("@DNI", DNIClienteBusc, SqlDbType.Int, 100);
                DataTable dt = BussinesDataLayer.DataAccess.ExcecuteDTbyProcedure("PA_GetCliente", parameters);
                return dt;
            }

        public DataTable GetVencimiento()
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = BussinesDataLayer.DataAccess.AddParameter("Id_Plan", IDPlanVencimiento, SqlDbType.Int, 50);
            DataTable dt = BussinesDataLayer.DataAccess.ExcecuteDTbyProcedure("PA_GetVencimiento", parameters);
            return dt;
        }

        public void AddCuota()
        {
            SqlParameter[] parameters = new SqlParameter[5];
            parameters[0] = BussinesDataLayer.DataAccess.AddParameter("@FK_Plan", FK_planCuota, SqlDbType.Int, 50);
            parameters[1] = BussinesDataLayer.DataAccess.AddParameter("@Monto", MontoCuota, SqlDbType.Money, 50);
            parameters[2] = BussinesDataLayer.DataAccess.AddParameter("@Fecha", FechaCuota, SqlDbType.DateTime, 30);
            parameters[3] = BussinesDataLayer.DataAccess.AddParameter("@Vencimiento", VencimientoCuota, SqlDbType.Date, 20);
            parameters[4] = BussinesDataLayer.DataAccess.AddParameter("@FK_Cliente", FK_clienteCuota, SqlDbType.Int, 50);
            DataTable dt = BussinesDataLayer.DataAccess.ExcecuteDTbyProcedure("PA_AddCuota", parameters);
        }


        //método para consultar un empleado
        public DataTable GetEmpleadoNom()
            {
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = BussinesDataLayer.DataAccess.AddParameter("@Nombre", NombreEmpleadoBusc, SqlDbType.NVarChar, 50);
                parameters[1] = BussinesDataLayer.DataAccess.AddParameter("@ID", IDEmpleadoBusc, SqlDbType.Int, 50);
                //parameters[2] = BussinesDataLayer.DataAccess.AddParameter("@K_cargo", CargoEmpleadoBusc, SqlDbType.Int, 50);
                DataTable dt = BussinesDataLayer.DataAccess.ExcecuteDTbyProcedure("PA_GetEmpleado", parameters);
                return dt;
            }

        public void UpdateCliente()
        {
            SqlParameter[] parameters = new SqlParameter[11];
            parameters[0] = BussinesDataLayer.DataAccess.AddParameter("@Nombre", NombreClienteEditar, SqlDbType.NVarChar, 50);
            parameters[1] = BussinesDataLayer.DataAccess.AddParameter("@Apellido", ApellidoClienteEditar, SqlDbType.NVarChar, 50);
            parameters[2] = BussinesDataLayer.DataAccess.AddParameter("@Fecha_nac", FechaClienteEditar, SqlDbType.Date, 50);
            parameters[3] = BussinesDataLayer.DataAccess.AddParameter("@Email", EmailClienteEditar, SqlDbType.NVarChar, 100);
            parameters[4] = BussinesDataLayer.DataAccess.AddParameter("@Telefono", TelefonoClienteEditar, SqlDbType.BigInt, 50);
            parameters[5] = BussinesDataLayer.DataAccess.AddParameter("@Calle", CalleClienteEditar, SqlDbType.NVarChar, 50);
            parameters[6] = BussinesDataLayer.DataAccess.AddParameter("@Numero", NumeroClienteEditar, SqlDbType.Int, 50);
            parameters[7] = BussinesDataLayer.DataAccess.AddParameter("@Barrio", BarrioClienteEditar, SqlDbType.NVarChar, 50);
            parameters[8] = BussinesDataLayer.DataAccess.AddParameter("@FK_localidad", FKLocalidadClienteEditar, SqlDbType.NVarChar, 50);
            parameters[9] = BussinesDataLayer.DataAccess.AddParameter("@DNI", DNIClienteEditar, SqlDbType.Int, 100);
            parameters[10] = BussinesDataLayer.DataAccess.AddParameter("@DNIEdit", DNIEditar, SqlDbType.Int, 100);

            DataTable dt = BussinesDataLayer.DataAccess.ExcecuteDTbyProcedure("PA_UpdateCliente", parameters);
        }

            public DataTable GetActividad()
            {
                SqlParameter[] parameters = new SqlParameter[0];
                DataTable dt = BussinesDataLayer.DataAccess.ExcecuteDTbyProcedure("PA_GetAllActividades", parameters);
                return dt;
            }

            public DataTable GetCargos()
            {
                SqlParameter[] parameters = new SqlParameter[0];
                DataTable dt = BussinesDataLayer.DataAccess.ExcecuteDTbyProcedure("PA_GetAllCargos", parameters);
                return dt;
            }


            //Obtener todos los profesores
            public DataTable GetProfesores()
            {
                SqlParameter[] parameters = new SqlParameter[0];
                DataTable dt = BussinesDataLayer.DataAccess.ExcecuteDTbyProcedure("PA_GetAllProfesores", parameters);
                return dt;
            }

            public DataTable GetSucursales()
            {
                SqlParameter[] parameters = new SqlParameter[0];
                DataTable dt = BussinesDataLayer.DataAccess.ExcecuteDTbyProcedure("PA_GetAllSucursales", parameters);
                return dt;
            }

        public DataTable GetAllPlans()
        {
            SqlParameter[] parameters = new SqlParameter[0];
            //parameters[0] = DataLayer.DataAccess.AddParameter("@Nombre", NombrePlanBusc, SqlDbType.VarChar, 50);
            DataTable dt = BussinesDataLayer.DataAccess.ExcecuteDTbyProcedure("PA_GetAllPlan", parameters);
            return dt;
        }

        public DataTable GetAllMedioPago()
        {
            SqlParameter[] parameters = new SqlParameter[0];
            //parameters[0] = DataLayer.DataAccess.AddParameter("@Nombre", NombrePlanBusc, SqlDbType.VarChar, 50);
            DataTable dt = BussinesDataLayer.DataAccess.ExcecuteDTbyProcedure("PA_GetAllMedioPago", parameters);
            return dt;
        }

        //Metodo para Registrar Cliente 
        public void AddNewCliente()
        {
            SqlParameter[] parameters = new SqlParameter[12];
            parameters[0] = BussinesDataLayer.DataAccess.AddParameter("@Nombre", NombreCliente, SqlDbType.NVarChar, 50);
            parameters[1] = BussinesDataLayer.DataAccess.AddParameter("@Apellido", ApellidoCliente, SqlDbType.NVarChar, 50);
            parameters[2] = BussinesDataLayer.DataAccess.AddParameter("@Fecha_Nac", FechaCliente, SqlDbType.Date, 50);
            parameters[3] = BussinesDataLayer.DataAccess.AddParameter("@Email", EmailCliente, SqlDbType.NVarChar, 100);
            parameters[4] = BussinesDataLayer.DataAccess.AddParameter("@Telefono", TelefonoCliente, SqlDbType.BigInt, 50);
            parameters[5] = BussinesDataLayer.DataAccess.AddParameter("@Calle", CalleCliente, SqlDbType.NVarChar, 50);
            parameters[6] = BussinesDataLayer.DataAccess.AddParameter("@Numero", NumeroCliente, SqlDbType.Int, 50);
            parameters[7] = BussinesDataLayer.DataAccess.AddParameter("@Barrio", BarrioCliente, SqlDbType.NVarChar, 50);
            parameters[8] = BussinesDataLayer.DataAccess.AddParameter("@FK_localidad", FKLocalidadCliente, SqlDbType.Int, 50);
            parameters[9] = BussinesDataLayer.DataAccess.AddParameter("@Foto", FotoCliente, SqlDbType.NVarChar, 500);
            parameters[10] = BussinesDataLayer.DataAccess.AddParameter("@DNI", DNICliente, SqlDbType.Int, 100);
            parameters[11] = BussinesDataLayer.DataAccess.AddParameter("@FK_TipoDocumento", FKTipoDocumento, SqlDbType.Int, 50);
            DataTable dt = BussinesDataLayer.DataAccess.ExcecuteDTbyProcedure("PA_AddCliente", parameters);
        }

        public DataTable GetTotalPlan()
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = BussinesDataLayer.DataAccess.AddParameter("@Id_plan", IdPlanMonto, SqlDbType.Int, 50);
            DataTable dt = BussinesDataLayer.DataAccess.ExcecuteDTbyProcedure("PA_GetMontoPlan", parameters);
            return dt;
        }

        public DataTable GetAllDatosCliente()
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = BussinesDataLayer.DataAccess.AddParameter("@Id_cliente", IdClienteSearch, SqlDbType.Int, 50);
            DataTable dt = BussinesDataLayer.DataAccess.ExcecuteDTbyProcedure("PA_GetAllDatosCliente", parameters);
            return dt;
        }


    }
}
