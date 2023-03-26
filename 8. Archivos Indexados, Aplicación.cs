using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO;

namespace EjercicioNo2Archivos
{
    class Program
    {


        static void Main(string[] args)
        {

            ConsoleKeyInfo op;
            Program lObjProceso = new Program();

            do
            {
                lObjProceso.SubMenuPrincipal();

                op = Console.ReadKey(true); //Que no muestre la tecla señalada
                Console.WriteLine(op.Key);
                //métodos son acciones, las propiedades son valores

                switch (op.Key)
                {
                    case ConsoleKey.NumPad1:
                        lObjProceso.SubAgregarPuesto();
                        Console.ReadKey();

                        break;
                    case ConsoleKey.D1:
                        lObjProceso.SubAgregarPuesto();
                        Console.ReadKey();
                        break;

                    case ConsoleKey.NumPad2:
                        lObjProceso.SubAgregarEmpleado();
                        Console.ReadKey();

                        break;
                    case ConsoleKey.D2:
                        lObjProceso.SubAgregarEmpleado();
                        Console.ReadKey();
                        break;
                    case ConsoleKey.NumPad3:
                        lObjProceso.SubListarInformacionArchivo();
                        Console.ReadKey();

                        break;
                    case ConsoleKey.D3:
                        lObjProceso.SubListarInformacionArchivo();
                        Console.ReadKey();
                        break;

                    case ConsoleKey.NumPad4:
                        lObjProceso.SubProcesoAumentoSalario();
                        Console.ReadKey();

                        break;
                    case ConsoleKey.D4:
                        lObjProceso.SubProcesoAumentoSalario();
                        Console.ReadKey();
                        break;

                    //case ConsoleKey.NumPad5:
                    //    lObjProceso.SubListarInformacionArchivo();
                    //    Console.ReadKey();

                    //    break;
                    //case ConsoleKey.D5:
                    //    lObjProceso.SubListarInformacionArchivo();
                    //    Console.ReadKey();
                    //    break;
                    //case ConsoleKey.NumPad6:
                    //    Environment.Exit(0);

                    //    break;
                    case ConsoleKey.D5:
                        Environment.Exit(0);
                        break;
                    case ConsoleKey.NumPad5:
                        Environment.Exit(0);
                        break;
                    case ConsoleKey.Escape:
                        Console.WriteLine("SALIENDO DEL SISTEMA.");

                        break;
                }
            } while ((op.Key != ConsoleKey.Escape));
        }

        public void SubMenuPrincipal()
        {
            Console.Clear(); //Limpiar la pantalla
            Console.Title = "EJERCICIO DE MENUS Y ARCHIVOS"; // Titulo de la pantalla.
            string StrTitulo = "EJERCICIO DE MENUS Y ARCHIVOS";
            Console.SetCursorPosition((Console.WindowWidth - StrTitulo.Length) / 2, Console.CursorTop); //Centrar cursor para desplegar el titulo.
            Console.WriteLine(StrTitulo);
            Console.WriteLine(string.Concat(Enumerable.Repeat("=", 115)));
            Console.SetCursorPosition(25, 2); Console.WriteLine("CURSO: PROGRAMACIÓN 1 ");
            Console.SetCursorPosition(25, 3); Console.WriteLine("NOMBRE: FRANCISCO RODRIGUEZ");
            Console.SetCursorPosition(25, 4); Console.WriteLine("CARNET: 0900-13-16825");
            Console.SetCursorPosition(25, 5); Console.WriteLine("SECCION: B");
            Console.WriteLine(string.Concat(Enumerable.Repeat("=", 115)));
            StrTitulo = "MENU PRINCIPAL";
            Console.SetCursorPosition((Console.WindowWidth - StrTitulo.Length) / 2, Console.CursorTop); //Centrar cursor para desplegar el titulo.
            Console.WriteLine(StrTitulo);
            Console.WriteLine(string.Concat(Enumerable.Repeat("=", 115)));
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(30, 09); Console.WriteLine("    1. Alta Puesto");
            Console.SetCursorPosition(30, 10); Console.WriteLine("    2. Alta Empleado");
            Console.SetCursorPosition(30, 11); Console.WriteLine("    3. Ver Planilla Sueldo");
            Console.SetCursorPosition(30, 12); Console.WriteLine("    4. Incremento 5% al Sueldo");
            Console.SetCursorPosition(30, 12); Console.WriteLine("    4. Modificar DAtos de Empleado");
            Console.SetCursorPosition(30, 12); Console.WriteLine("    4. eliminar empleado");
            Console.SetCursorPosition(30, 14); Console.WriteLine("    5. Salida [Esc]");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(string.Concat(Enumerable.Repeat("=", 115)));
            Console.SetCursorPosition(30, 16); Console.WriteLine("   ELIJA EL NÚMERO DE OPCIÓN [  ]          ");
            Console.WriteLine(string.Concat(Enumerable.Repeat("=", 115)));
            Console.SetCursorPosition(61, 16);
        }

        public static bool FncValidaPuesto(int pIntPuesto)
        {
            bool lBlnResultado = false;
            String lstrCadena = string.Empty;
            int lintPuestoRevision = 0;
            if (File.Exists("c:/pmo/puestos.txt"))
            {
                using (Stream ms = new MemoryStream())
                {
                    using (Stream fs = new FileStream("c:/pmo/puestos.txt", FileMode.Open, FileAccess.Read))
                    {
                        fs.CopyTo(ms);
                    }

                    ms.Seek(0, SeekOrigin.Begin);
                    using (StreamReader sr = new StreamReader(ms))
                    {
                        bool lBlnSeguir = false;
                        while ((lstrCadena = sr.ReadLine()) != null && (lBlnSeguir == false))
                        {

                            String[] lStrConjuntoDatos = lstrCadena.Split('|');
                            lintPuestoRevision = int.Parse(lStrConjuntoDatos[0]);
                            if (lintPuestoRevision == pIntPuesto)
                            {
                                lBlnResultado = true;
                                lBlnSeguir = true;
                            }
                        }

                    }
                }
            }
            else
            {
                lBlnResultado = false;
            }

            return lBlnResultado;
        }
        public void SubAgregarPuesto()
        {

            string lStrInformacion = string.Empty;
            String lstrCadena = string.Empty;
            int lintIdPuesto = 0;
            Boolean lblnContinuaIngresando = true;
            String lStrDeseaContinuar = string.Empty;
            string lStrNombre = string.Empty;
            double lDblSueldo = 0;
            string lStrSeparador = "|";
            Console.Clear(); //Limpiar la pantalla                       
            try
            {

                if (File.Exists("c:/pmo/puestos.txt"))
                {
                    using (Stream ms = new MemoryStream())
                    {
                        using (Stream fs = new FileStream("c:/pmo/puestos.txt", FileMode.Open, FileAccess.Read))
                        {
                            fs.CopyTo(ms);
                        }

                        ms.Seek(0, SeekOrigin.Begin);
                        using (StreamReader sr = new StreamReader(ms))
                        {
                            while ((lstrCadena = sr.ReadLine()) != null)
                            {

                                String[] lStrConjuntoDatos = lstrCadena.Split('|');
                                lintIdPuesto = int.Parse(lStrConjuntoDatos[0]);
                            }
                            lintIdPuesto += 1;
                        }
                    }
                }
                else
                {
                    lintIdPuesto = 1;
                }
                if (lintIdPuesto != 0)
                {
                    using (StreamWriter sw = new StreamWriter(new FileStream("c:/pmo/puestos.txt", FileMode.Append)))
                    {
                        while (lblnContinuaIngresando == true)
                        {

                            Console.Clear(); //Limpiar la pantalla
                            Console.SetCursorPosition(0, 3);
                            string StrTitulo = "INFORMACION A COMPLETAR DEL PUESTOS";
                            Console.SetCursorPosition((Console.WindowWidth - StrTitulo.Length) / 2, Console.CursorTop); //Centrar cursor para desplegar el titulo.
                            Console.WriteLine(StrTitulo);


                            Console.SetCursorPosition(25, 5); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 85)));
                            Console.SetCursorPosition(35, 6); Console.WriteLine("DATOS GENERALES ");
                            Console.SetCursorPosition(25, 7); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 85)));
                            Console.SetCursorPosition(35, 8); Console.WriteLine("ID PUESTO       :            [                                          ]");
                            Console.SetCursorPosition(35, 9); Console.WriteLine("NOMBRE PUESTO   :            [                                          ]");
                            Console.SetCursorPosition(25, 12); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 85)));
                            Console.SetCursorPosition(35, 13); Console.WriteLine("DATOS ESPECIFICOS");
                            Console.SetCursorPosition(25, 14); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 85)));
                            Console.SetCursorPosition(35, 15); Console.WriteLine("SALARIO        :        [                                          ]");
                            Console.SetCursorPosition(25, 17); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 85)));
                            Console.SetCursorPosition(70, 8); Console.WriteLine(Convert.ToString(lintIdPuesto).PadLeft(4, '0'));
                            Console.SetCursorPosition(70, 9); lStrNombre = Console.ReadLine();
                            Console.SetCursorPosition(70, 15); lDblSueldo = double.Parse(Console.ReadLine());

                            Console.SetCursorPosition(40, 18); Console.WriteLine("DESEA CONTINUAR INGRESANDO REGISTROS S/N:        [  ]");
                            Console.SetCursorPosition(90, 18); lStrDeseaContinuar = Console.ReadLine();

                            sw.Write(Convert.ToString(lintIdPuesto).PadRight(4, ' ')); sw.Write(lStrSeparador);
                            sw.Write(lStrNombre.PadRight(30, ' ')); sw.Write(lStrSeparador);
                            sw.WriteLine(Convert.ToString(lDblSueldo).PadLeft(10, '0'));
                            if (lStrDeseaContinuar.ToUpper() == "N")
                            {
                                lblnContinuaIngresando = false;
                            }
                            lintIdPuesto += 1;

                        }
                        sw.Close();
                        //Cerrar el archivo

                        Console.Write("            Presione una tecla para continuar...");
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR EN INTERACCION CON ARCHIVO: " + e.Message);
            }
            finally
            {

            }


        }

        public void SubAgregarEmpleado()
        {

            string lStrInformacion = string.Empty;
            String lstrCadena = string.Empty;
            int lintIdEmpleado = 0;
            int lintIdPuesto = 0;
            Boolean lblnContinuaIngresando = true;
            String lStrDeseaContinuar = string.Empty;
            string lStrNombre = string.Empty;
            string lStrDireccion = string.Empty;
            string lStrTelefono = string.Empty;
            string lStrSeparador = "|";
            Console.Clear(); //Limpiar la pantalla                       
            try
            {

                if (File.Exists("c:/pmo/empleado.txt"))
                {
                    using (Stream ms = new MemoryStream())
                    {
                        using (Stream fs = new FileStream("c:/pmo/empleado.txt", FileMode.Open, FileAccess.Read))
                        {
                            fs.CopyTo(ms);
                        }

                        ms.Seek(0, SeekOrigin.Begin);
                        using (StreamReader sr = new StreamReader(ms))
                        {
                            while ((lstrCadena = sr.ReadLine()) != null)
                            {

                                String[] lStrConjuntoDatos = lstrCadena.Split('|');
                                lintIdEmpleado = int.Parse(lStrConjuntoDatos[0]);
                            }
                            lintIdEmpleado += 1;
                        }
                    }
                }
                else
                {
                    lintIdEmpleado = 1;
                }
                if (lintIdEmpleado != 0)
                {
                    using (StreamWriter sw = new StreamWriter(new FileStream("c:/pmo/empleado.txt", FileMode.Append)))
                    {
                        while (lblnContinuaIngresando == true)
                        {

                            Console.Clear(); //Limpiar la pantalla
                            Console.SetCursorPosition(0, 3);
                            string StrTitulo = "INFORMACION A COMPLETAR DEL EMPLEADO";
                            Console.SetCursorPosition((Console.WindowWidth - StrTitulo.Length) / 2, Console.CursorTop); //Centrar cursor para desplegar el titulo.
                            Console.WriteLine(StrTitulo);


                            Console.SetCursorPosition(25, 5); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 85)));
                            Console.SetCursorPosition(35, 6); Console.WriteLine("DATOS GENERALES ");
                            Console.SetCursorPosition(25, 7); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 85)));
                            Console.SetCursorPosition(35, 8); Console.WriteLine("ID EMPLEADO     :            [                                          ]");
                            Console.SetCursorPosition(35, 9); Console.WriteLine("NOMBRE EMPLEADO :            [                                          ]");
                            Console.SetCursorPosition(35, 10); Console.WriteLine("DIRECCION      :            [                                          ]");
                            Console.SetCursorPosition(35, 11); Console.WriteLine("TELEFONO       :            [                                          ]");
                            Console.SetCursorPosition(25, 12); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 85)));
                            Console.SetCursorPosition(35, 13); Console.WriteLine("DATOS ESPECIFICOS");
                            Console.SetCursorPosition(25, 14); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 85)));
                            Console.SetCursorPosition(35, 15); Console.WriteLine("ID PUESTO      :        [                                          ]");
                            Console.SetCursorPosition(25, 17); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 85)));
                            Console.SetCursorPosition(70, 8); Console.WriteLine(Convert.ToString(lintIdEmpleado).PadLeft(4, '0'));
                            Console.SetCursorPosition(70, 9); lStrNombre = Console.ReadLine();
                            Console.SetCursorPosition(70, 10); lStrDireccion = Console.ReadLine();
                            Console.SetCursorPosition(70, 11); lStrTelefono = Console.ReadLine();
                            Console.SetCursorPosition(70, 15); lintIdPuesto = int.Parse(Console.ReadLine());
                            bool blnValidar = false;
                            blnValidar = FncValidaPuesto(lintIdPuesto);
                            while (blnValidar == false)
                            {
                                Console.SetCursorPosition(35, 22); Console.WriteLine("EL ID NO EXISTE.");
                                Console.SetCursorPosition(70, 15); Console.WriteLine("         ");
                                Console.SetCursorPosition(70, 15); lintIdPuesto = int.Parse(Console.ReadLine());
                                blnValidar = FncValidaPuesto(lintIdPuesto);
                            }

                            sw.Write(Convert.ToString(lintIdEmpleado).PadRight(4, ' ')); sw.Write(lStrSeparador);
                            sw.Write(lStrNombre.PadRight(30, ' ')); sw.Write(lStrSeparador);
                            sw.Write(lStrDireccion.PadRight(30, ' ')); sw.Write(lStrSeparador);
                            sw.Write(lStrTelefono.PadRight(30, ' ')); sw.Write(lStrSeparador);
                            sw.WriteLine(Convert.ToString(lintIdPuesto).PadRight(4, ' '));
                            if (lStrDeseaContinuar.ToUpper() == "N")
                            {
                                lblnContinuaIngresando = false;
                            }
                            lintIdEmpleado += 1;
                            Console.SetCursorPosition(40, 18); Console.WriteLine("DESEA CONTINUAR INGRESANDO REGISTROS S/N:        [  ]");
                            Console.SetCursorPosition(90, 18); lStrDeseaContinuar = Console.ReadLine();

                        }
                        sw.Close();
                        //Cerrar el archivo

                        Console.Write("            Presione una tecla para continuar...");
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR EN INTERACCION CON ARCHIVO: " + e.Message);
            }
            finally
            {

            }


        }

        public struct PuestoTrabajo
        {
            public int lIntPuesto;
            public string lStrNombrePUesto;
            public double lDblSueldo;
        }

        static List<PuestoTrabajo> FncObtienePuesto()
        {
            String lstrCadena = string.Empty;

            var lObjResultado = new List<PuestoTrabajo>();
            PuestoTrabajo lObjPuesto;
            if (File.Exists("c:/pmo/puestos.txt"))
            {
                using (Stream ms = new MemoryStream())
                {
                    using (Stream fs = new FileStream("c:/pmo/puestos.txt", FileMode.Open, FileAccess.Read))
                    {
                        fs.CopyTo(ms);
                    }

                    ms.Seek(0, SeekOrigin.Begin);
                    using (StreamReader sr = new StreamReader(ms))
                    {
                        while ((lstrCadena = sr.ReadLine()) != null)
                        {
                            String[] lStrConjuntoDatos = lstrCadena.Split('|');
                            lObjPuesto.lIntPuesto = int.Parse(lStrConjuntoDatos[0]);
                            lObjPuesto.lStrNombrePUesto = Convert.ToString(lStrConjuntoDatos[1]);
                            lObjPuesto.lDblSueldo = double.Parse(lStrConjuntoDatos[2]);


                            lObjResultado.Add(lObjPuesto);
                        }

                    }
                }
            }

            return lObjResultado;
        }


        public void SubListarInformacionArchivo()
        {
            Console.Clear(); //Limpiar la pantalla    

            try
            {
                // ABRIENDO EL ARCHIVO
                using (var sr = new StreamReader("c:/pmo/empleado.txt"))
                {
                    // LEYENDO LA INFORMACION.
                    Console.WriteLine("        ________________________________________________________________");

                    String lstrCadena;
                    int lIntLinea = 9;
                    Console.Clear(); //Limpiar la pantalla
                    Console.SetCursorPosition(0, 3);
                    string StrTitulo = "PLANILLA LABORAL";
                    Console.SetCursorPosition((Console.WindowWidth - StrTitulo.Length) / 2, Console.CursorTop); //Centrar cursor para desplegar el titulo.
                    Console.WriteLine(StrTitulo);

                    Console.SetCursorPosition(5, 5); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                    StrTitulo = "DETALLE DE INFORMACION";
                    Console.SetCursorPosition((Console.WindowWidth - StrTitulo.Length) / 2, Console.CursorTop); //Centrar cursor para desplegar el titulo.
                    Console.WriteLine("DETALLE DE INFORMACION");
                    Console.SetCursorPosition(5, 7); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                    Console.SetCursorPosition(5, 8); Console.WriteLine("NOMBRE EMPLEADO                NOMBRE PUESTO       SUELDO       CUOTA PATRONAL   SUELDO LIQUIDO");

                    List<PuestoTrabajo> lobjPuestos = FncObtienePuesto();




                    while ((lstrCadena = sr.ReadLine()) != null)
                    {

                        String[] lStrConjuntoDatos = lstrCadena.Split('|');
                        String lStrPuesto = string.Empty;

                        double lDblCuotaPatronal = 0.00;
                        double lDblSalarioLiquido = 0.00;
                        Console.SetCursorPosition(5, lIntLinea); Console.Write(lStrConjuntoDatos[1]);
                        foreach (PuestoTrabajo lObjPuesto in lobjPuestos)
                        {
                            if (lObjPuesto.lIntPuesto == int.Parse(lStrConjuntoDatos[4]))
                            {
                                Console.SetCursorPosition(37, lIntLinea); Console.Write(lObjPuesto.lStrNombrePUesto);
                                Console.SetCursorPosition(57, lIntLinea); Console.Write(lObjPuesto.lDblSueldo.ToString("N2"));
                                lDblCuotaPatronal = lObjPuesto.lDblSueldo * 0.0483;
                                lDblSalarioLiquido = lObjPuesto.lDblSueldo - lDblCuotaPatronal;
                                Console.SetCursorPosition(70, lIntLinea); Console.Write(lDblCuotaPatronal.ToString("N2"));
                                Console.SetCursorPosition(90, lIntLinea); Console.Write(lDblSalarioLiquido.ToString("N2"));
                                lIntLinea += 1;
                                break;
                            }
                        }


                    }
                    Console.SetCursorPosition(5, lIntLinea); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                }


                Console.SetCursorPosition(30, 30); Console.Write("            Presione una tecla para continuar...");

            }
            catch (IOException e)
            {
                Console.WriteLine("        ________________________________________________________________");
                Console.WriteLine("            OCURRIO UN ERROR AL LEER EL ARCHIVO, FAVOR REVISE");
                Console.WriteLine("   " + e.Message);
                Console.WriteLine("        ________________________________________________________________");

            }

        }

        public void SubProcesoAumentoSalario()
        {
            Console.Clear(); //Limpiar la pantalla    

            try
            {
                // ABRIENDO EL ARCHIVO
                string lStrSeparador = "|";
                StreamWriter lObjArchivoFinal;
                using (var sr = new StreamReader("c:/pmo/Puestos.txt"))
                {
                    // LEYENDO LA INFORMACION.
                    lObjArchivoFinal = File.CreateText("c:/pmo/temp.txt");
                    Console.WriteLine("        ________________________________________________________________");

                    String lstrCadena;
                    int lIntLinea = 9;
                    Console.Clear(); //Limpiar la pantalla
                    Console.SetCursorPosition(0, 3);
                    string StrTitulo = "PLANILLA LABORAL";
                    Console.SetCursorPosition((Console.WindowWidth - StrTitulo.Length) / 2, Console.CursorTop); //Centrar cursor para desplegar el titulo.
                    Console.WriteLine(StrTitulo);

                    Console.SetCursorPosition(5, 5); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                    StrTitulo = "AUMENTO SALARIO";
                    Console.SetCursorPosition((Console.WindowWidth - StrTitulo.Length) / 2, Console.CursorTop); //Centrar cursor para desplegar el titulo.
                    Console.WriteLine("DETALLE DE INFORMACION");
                    Console.SetCursorPosition(5, 7); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                    Console.SetCursorPosition(5, 8); Console.WriteLine(" ID        NOMBRE PUESTO       SUELDO ACTUAL    AUMENTO   SALARIO NUEVO");

                    while ((lstrCadena = sr.ReadLine()) != null)
                    {

                        String[] lStrConjuntoDatos = lstrCadena.Split('|');
                        double lDblAumento;
                        double lDblSalarioNuevo;
                        Console.SetCursorPosition(5, lIntLinea); Console.Write(lStrConjuntoDatos[0]);
                        Console.SetCursorPosition(15, lIntLinea); Console.Write(lStrConjuntoDatos[1]);
                        lDblAumento = double.Parse(lStrConjuntoDatos[2]) * 0.05;
                        lDblSalarioNuevo = double.Parse(lStrConjuntoDatos[2]) + lDblAumento;
                        Console.SetCursorPosition(38, lIntLinea); Console.Write(double.Parse(lStrConjuntoDatos[2]).ToString("N2"));
                        Console.SetCursorPosition(56, lIntLinea); Console.Write(lDblAumento.ToString("N2"));
                        Console.SetCursorPosition(67, lIntLinea); Console.Write(lDblSalarioNuevo.ToString("N2"));
                        lObjArchivoFinal.Write(Convert.ToString(lStrConjuntoDatos[0]).PadRight(4, ' ')); lObjArchivoFinal.Write(lStrSeparador);
                        lObjArchivoFinal.Write(lStrConjuntoDatos[1].PadRight(30, ' ')); lObjArchivoFinal.Write(lStrSeparador);
                        lObjArchivoFinal.WriteLine(Convert.ToString(lDblSalarioNuevo).PadLeft(10, '0'));
                        lIntLinea += 1;

                    }
                    sr.Close();
                    lObjArchivoFinal.Close();
                    File.Delete("c:/pmo/puestos.txt");
                    File.Move("c:/pmo/temp.txt", "c:/pmo/puestos.txt");
                    Console.SetCursorPosition(5, lIntLinea); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                }

                Console.SetCursorPosition(30, 30); Console.Write("            Presione una tecla para continuar...");

            }
            catch (IOException e)
            {
                Console.WriteLine("        ________________________________________________________________");
                Console.WriteLine("            OCURRIO UN ERROR AL LEER EL ARCHIVO, FAVOR REVISE");
                Console.WriteLine("   " + e.Message);
                Console.WriteLine("        ________________________________________________________________");

            }

        }

    }
}
