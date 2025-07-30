using Controladora;
using Entidades.Tickets;

namespace CarFix.Tests.UnitTests
{
    [TestClass]
    public class ControladoraTicketsTests
    {
        private ControladoraTickets controladora;

        [TestInitialize]
        public void Setup()
        {
            controladora = ControladoraTickets.Instancia;
        }

        [TestCleanup]
        public void Cleanup()
        {

        }

        // ====================================================================================
        // PRUEBAS DE RUTA BÁSICA - MÉTODO ValidarTicket
        // Complejidad Ciclomática: 9
        // Rutas Independientes: 9
        // ====================================================================================

        /// <summary>
        /// Caso de Prueba R1: Ticket Nulo
        /// Ruta: 1→2→20
        /// Descripción: Validar que se detecte cuando el ticket es nulo
        /// </summary>
        [TestMethod]
        public void ValidarTicket_TicketNulo_DebeRetornarError()
        {
            // Arrange
            Ticket ticket = null;

            // Act
            var resultado = controladora.ValidarTicket(ticket);

            // Assert
            Assert.IsFalse(resultado.EsValido, "El resultado debería ser no válido");
            Assert.AreEqual(1, resultado.Errores.Count, "Debería haber exactamente 1 error");
            Assert.AreEqual("El ticket no puede ser nulo", resultado.Errores[0], "Mensaje de error incorrecto");
        }

        /// <summary>
        /// Caso de Prueba R2: Descripción Nula
        /// Ruta: 1→3→4→20
        /// Descripción: Validar que se detecte descripción nula o vacía
        /// </summary>
        [TestMethod]
        public void ValidarTicket_DescripcionNula_DebeRetornarError()
        {
            // Arrange
            var ticket = new Ticket
            {
                Descripcion = null, // Descripción nula
                ClienteId = 1,
                TecnicoId = 1,
                VehiculoId = 1,
                FechaCreacion = DateTime.Now,
                Estado = Ticket.EnumEstados.Asignado
            };

            // Act
            var resultado = controladora.ValidarTicket(ticket);

            // Assert
            Assert.IsFalse(resultado.EsValido, "El resultado debería ser no válido");
            Assert.IsTrue(resultado.Errores.Count > 0, "Debería haber al menos un error");
            Assert.IsTrue(resultado.Errores.Contains("La descripción es requerida"),
                "Debería contener el error de descripción requerida");
        }

        /// <summary>
        /// Caso de Prueba R2b: Descripción Vacía
        /// Ruta: 1→3→4→20
        /// Descripción: Validar que se detecte descripción vacía
        /// </summary>
        [TestMethod]
        public void ValidarTicket_DescripcionVacia_DebeRetornarError()
        {
            // Arrange
            var ticket = new Ticket
            {
                Descripcion = "", // Descripción vacía
                ClienteId = 1,
                TecnicoId = 1,
                VehiculoId = 1,
                FechaCreacion = DateTime.Now,
                Estado = Ticket.EnumEstados.Asignado
            };

            // Act
            var resultado = controladora.ValidarTicket(ticket);

            // Assert
            Assert.IsFalse(resultado.EsValido, "El resultado debería ser no válido");
            Assert.IsTrue(resultado.Errores.Contains("La descripción es requerida"),
                "Debería contener el error de descripción requerida");
        }

        /// <summary>
        /// Caso de Prueba R3: Descripción Muy Larga
        /// Ruta: 1→3→5→6→20
        /// Descripción: Validar que se detecte descripción > 500 caracteres
        /// </summary>
        [TestMethod]
        public void ValidarTicket_DescripcionMuyLarga_DebeRetornarError()
        {
            // Arrange
            var ticket = new Ticket
            {
                Descripcion = new string('A', 501), // 501 caracteres
                ClienteId = 1,
                TecnicoId = 1,
                VehiculoId = 1,
                FechaCreacion = DateTime.Now,
                Estado = Ticket.EnumEstados.Asignado
            };

            // Act
            var resultado = controladora.ValidarTicket(ticket);

            // Assert
            Assert.IsFalse(resultado.EsValido, "El resultado debería ser no válido");
            Assert.IsTrue(resultado.Errores.Contains("La descripción no puede exceder 500 caracteres"),
                "Debería contener el error de longitud máxima");
        }

        /// <summary>
        /// Caso de Prueba R4: Cliente Inválido
        /// Ruta: 1→3→5→7→8→20
        /// Descripción: Validar que se detecte ClienteId <= 0
        /// </summary>
        [TestMethod]
        public void ValidarTicket_ClienteInvalido_DebeRetornarError()
        {
            // Arrange
            var ticket = new Ticket
            {
                Descripcion = "Descripción válida",
                ClienteId = 0, // Cliente inválido
                TecnicoId = 1,
                VehiculoId = 1,
                FechaCreacion = DateTime.Now,
                Estado = Ticket.EnumEstados.Asignado
            };

            // Act
            var resultado = controladora.ValidarTicket(ticket);

            // Assert
            Assert.IsFalse(resultado.EsValido, "El resultado debería ser no válido");
            Assert.IsTrue(resultado.Errores.Contains("Debe asignar un cliente válido"),
                "Debería contener el error de cliente válido");
        }

        /// <summary>
        /// Caso de Prueba R5: Técnico Inválido
        /// Ruta: 1→3→5→7→9→10→20
        /// Descripción: Validar que se detecte TecnicoId <= 0
        /// </summary>
        [TestMethod]
        public void ValidarTicket_TecnicoInvalido_DebeRetornarError()
        {
            // Arrange
            var ticket = new Ticket
            {
                Descripcion = "Descripción válida",
                ClienteId = 1,
                TecnicoId = -1, // Técnico inválido
                VehiculoId = 1,
                FechaCreacion = DateTime.Now,
                Estado = Ticket.EnumEstados.Asignado
            };

            // Act
            var resultado = controladora.ValidarTicket(ticket);

            // Assert
            Assert.IsFalse(resultado.EsValido, "El resultado debería ser no válido");
            Assert.IsTrue(resultado.Errores.Contains("Debe asignar un técnico válido"),
                "Debería contener el error de técnico válido");
        }

        /// <summary>
        /// Caso de Prueba R6: Vehículo Inválido
        /// Ruta: 1→3→5→7→9→11→12→20
        /// Descripción: Validar que se detecte VehiculoId <= 0
        /// </summary>
        [TestMethod]
        public void ValidarTicket_VehiculoInvalido_DebeRetornarError()
        {
            // Arrange
            var ticket = new Ticket
            {
                Descripcion = "Descripción válida",
                ClienteId = 1,
                TecnicoId = 1,
                VehiculoId = 0, // Vehículo inválido
                FechaCreacion = DateTime.Now,
                Estado = Ticket.EnumEstados.Asignado
            };

            // Act
            var resultado = controladora.ValidarTicket(ticket);

            // Assert
            Assert.IsFalse(resultado.EsValido, "El resultado debería ser no válido");
            Assert.IsTrue(resultado.Errores.Contains("Debe asignar un vehículo válido"),
                "Debería contener el error de vehículo válido");
        }

        /// <summary>
        /// Caso de Prueba R7: Fecha Futura
        /// Ruta: 1→3→5→7→9→11→13→14→20
        /// Descripción: Validar que se detecte fecha futura
        /// </summary>
        [TestMethod]
        public void ValidarTicket_FechaFutura_DebeRetornarError()
        {
            // Arrange
            var ticket = new Ticket
            {
                Descripcion = "Descripción válida",
                ClienteId = 1,
                TecnicoId = 1,
                VehiculoId = 1,
                FechaCreacion = DateTime.Now.AddDays(2), // Fecha futura
                Estado = Ticket.EnumEstados.Asignado
            };

            // Act
            var resultado = controladora.ValidarTicket(ticket);

            // Assert
            Assert.IsFalse(resultado.EsValido, "El resultado debería ser no válido");
            Assert.IsTrue(resultado.Errores.Contains("La fecha no puede ser futura"),
                "Debería contener el error de fecha futura");
        }

        /// <summary>
        /// Caso de Prueba R8: Estado Inválido
        /// Ruta: 1→3→5→7→9→11→13→15→16→20
        /// Descripción: Validar que se detecte estado inválido
        /// </summary>
        [TestMethod]
        public void ValidarTicket_EstadoInvalido_DebeRetornarError()
        {
            // Arrange
            var ticket = new Ticket
            {
                Descripcion = "Descripción válida",
                ClienteId = 1,
                TecnicoId = 1,
                VehiculoId = 1,
                FechaCreacion = DateTime.Now,
                Estado = (Ticket.EnumEstados)999 // Estado inválido
            };

            // Act
            var resultado = controladora.ValidarTicket(ticket);

            // Assert
            Assert.IsFalse(resultado.EsValido, "El resultado debería ser no válido");
            Assert.IsTrue(resultado.Errores.Contains("Estado del ticket inválido"),
                "Debería contener el error de estado inválido");
        }

        /// <summary>
        /// Caso de Prueba R9: Ticket Válido
        /// Ruta: 1→3→5→7→9→11→13→15→17→18→20
        /// Descripción: Validar que un ticket completamente válido pase la validación
        /// </summary>
        [TestMethod]
        public void ValidarTicket_TicketValido_DebeRetornarExito()
        {
            // Arrange
            var ticket = new Ticket
            {
                Descripcion = "Cambio de aceite y filtros - Mantenimiento preventivo",
                ClienteId = 1,
                TecnicoId = 1,
                VehiculoId = 1,
                FechaCreacion = DateTime.Now,
                Estado = Ticket.EnumEstados.Asignado
            };

            // Act
            var resultado = controladora.ValidarTicket(ticket);

            // Assert
            Assert.IsTrue(resultado.EsValido, "El resultado debería ser válido");
            Assert.AreEqual(0, resultado.Errores.Count, "No debería haber errores");
        }

        // ====================================================================================
        // PRUEBAS ADICIONALES - CASOS EDGE Y VALORES LÍMITE
        // ====================================================================================

        /// <summary>
        /// Caso Edge: Descripción exactamente 500 caracteres (límite máximo válido)
        /// </summary>
        [TestMethod]
        public void ValidarTicket_Descripcion500Caracteres_DebeSerValido()
        {
            // Arrange
            var ticket = new Ticket
            {
                Descripcion = new string('A', 500), // Exactamente 500 caracteres
                ClienteId = 1,
                TecnicoId = 1,
                VehiculoId = 1,
                FechaCreacion = DateTime.Now,
                Estado = Ticket.EnumEstados.Asignado
            };

            // Act
            var resultado = controladora.ValidarTicket(ticket);

            // Assert
            Assert.IsTrue(resultado.EsValido, "Descripción de 500 caracteres debería ser válida");
            Assert.AreEqual(0, resultado.Errores.Count, "No debería haber errores");
        }

        /// <summary>
        /// Caso Edge: Descripción de 1 carácter (límite mínimo válido)
        /// </summary>
        [TestMethod]
        public void ValidarTicket_Descripcion1Caracter_DebeSerValido()
        {
            // Arrange
            var ticket = new Ticket
            {
                Descripcion = "A", // 1 carácter
                ClienteId = 1,
                TecnicoId = 1,
                VehiculoId = 1,
                FechaCreacion = DateTime.Now,
                Estado = Ticket.EnumEstados.Asignado
            };

            // Act
            var resultado = controladora.ValidarTicket(ticket);

            // Assert
            Assert.IsTrue(resultado.EsValido, "Descripción de 1 carácter debería ser válida");
            Assert.AreEqual(0, resultado.Errores.Count, "No debería haber errores");
        }

        /// <summary>
        /// Caso Edge: Fecha límite (exactamente 1 día en el futuro - límite máximo)
        /// </summary>
        [TestMethod]
        public void ValidarTicket_FechaLimite1DiaFuturo_DebeSerValido()
        {
            // Arrange
            var ticket = new Ticket
            {
                Descripcion = "Descripción válida",
                ClienteId = 1,
                TecnicoId = 1,
                VehiculoId = 1,
                FechaCreacion = DateTime.Now.AddDays(1), // Exactamente 1 día futuro
                Estado = Ticket.EnumEstados.Asignado
            };

            // Act
            var resultado = controladora.ValidarTicket(ticket);

            // Assert
            Assert.IsTrue(resultado.EsValido, "Fecha 1 día en futuro debería ser válida");
            Assert.AreEqual(0, resultado.Errores.Count, "No debería haber errores");
        }

        /// <summary>
        /// Caso Edge: Múltiples errores simultáneos
        /// </summary>
        [TestMethod]
        public void ValidarTicket_MultiplesErrores_DebeReportarTodos()
        {
            // Arrange
            var ticket = new Ticket
            {
                Descripcion = null, // Error 1: Descripción nula
                ClienteId = 0,     // Error 2: Cliente inválido
                TecnicoId = -5,    // Error 3: Técnico inválido
                VehiculoId = 0,    // Error 4: Vehículo inválido
                FechaCreacion = DateTime.Now.AddDays(5), // Error 5: Fecha futura
                Estado = (Ticket.EnumEstados)999 // Error 6: Estado inválido
            };

            // Act
            var resultado = controladora.ValidarTicket(ticket);

            // Assert
            Assert.IsFalse(resultado.EsValido, "El resultado debería ser no válido");
            Assert.IsTrue(resultado.Errores.Count >= 5, "Debería haber múltiples errores reportados");

            // Verificar que todos los errores esperados están presentes
            Assert.IsTrue(resultado.Errores.Any(e => e.Contains("descripción")), "Debería reportar error de descripción");
            Assert.IsTrue(resultado.Errores.Any(e => e.Contains("cliente")), "Debería reportar error de cliente");
            Assert.IsTrue(resultado.Errores.Any(e => e.Contains("técnico")), "Debería reportar error de técnico");
            Assert.IsTrue(resultado.Errores.Any(e => e.Contains("vehículo")), "Debería reportar error de vehículo");
            Assert.IsTrue(resultado.Errores.Any(e => e.Contains("fecha")), "Debería reportar error de fecha");
        }

        // ====================================================================================
        // PRUEBAS DE CADA ESTADO VÁLIDO
        // ====================================================================================

        /// <summary>
        /// Validar que todos los estados válidos del enum sean aceptados
        /// </summary>
        [TestMethod]
        public void ValidarTicket_EstadosValidos_DebenSerAceptados()
        {
            // Arrange & Act & Assert para cada estado válido
            var estadosValidos = new[]
            {
                Ticket.EnumEstados.Asignado,
                Ticket.EnumEstados.EnProceso,
                Ticket.EnumEstados.Finalizado
            };

            foreach (var estado in estadosValidos)
            {
                var ticket = new Ticket
                {
                    Descripcion = $"Ticket en estado {estado}",
                    ClienteId = 1,
                    TecnicoId = 1,
                    VehiculoId = 1,
                    FechaCreacion = DateTime.Now,
                    Estado = estado
                };

                var resultado = controladora.ValidarTicket(ticket);

                Assert.IsTrue(resultado.EsValido, $"Estado {estado} debería ser válido");
                Assert.AreEqual(0, resultado.Errores.Count, $"No debería haber errores para estado {estado}");
            }
        }

        // ====================================================================================
        // HELPER METHODS PARA CREAR DATOS DE PRUEBA
        // ====================================================================================

        /// <summary>
        /// Crea un ticket base válido para usar en pruebas
        /// </summary>
        private Ticket CrearTicketValido()
        {
            return new Ticket
            {
                Descripcion = "Descripción de prueba válida",
                ClienteId = 1,
                TecnicoId = 1,
                VehiculoId = 1,
                FechaCreacion = DateTime.Now,
                Estado = Ticket.EnumEstados.Asignado
            };
        }

        /// <summary>
        /// Verifica que un resultado contenga un error específico
        /// </summary>
        private void VerificarError(ResultadoValidacion resultado, string mensajeEsperado)
        {
            Assert.IsFalse(resultado.EsValido, "El resultado debería ser no válido");
            Assert.IsTrue(resultado.Errores.Any(e => e.Contains(mensajeEsperado)),
                $"Debería contener el error: {mensajeEsperado}");
        }
    }
}