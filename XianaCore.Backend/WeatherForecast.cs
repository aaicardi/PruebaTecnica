using System;

namespace XianaCore.Backend
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}

/*
 // ***********************************************************************
// Assembly         : PlantillaMicroservicio.Core
// Author           : Alberto Palencia <alberto.palencia@XianaApp.com.co>
// Created          : 07-21-2020
//
// Last Modified By : Alberto Palencia <alberto.palencia@XianaApp.com.co>
// Last Modified On : 07-21-2020
// ***********************************************************************
// <copyright file="Enumeration.cs" company="PlantillaMicroservicio.Core">
//     Copyright (c) XianaApp. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace XM.Evento.ConsultaGeneral.Application.Enumerations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Class Enumeration.
    /// Implements the <see cref="IComparable" />
    /// </summary>
    /// <seealso cref="IComparable" />
    public abstract class Enumeration : IComparable
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Enumeration"/> class.
        /// </summary>
        protected Enumeration()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Enumeration"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        protected Enumeration(int id, string name)
        {
            Id = id; Name = name;
        }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="string" /> that represents this instance.</returns>
        public override string ToString() => Name;

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        public static IEnumerable<T> GetAll<T>() where T : Enumeration
        {
            var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly); return fields.Select(f => f.GetValue(null)).Cast<T>();
        }

        /// <summary>
        /// Determines whether the specified <see cref="object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            var otherValue = obj as Enumeration;
            if (otherValue == null) return false;
            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = Id.Equals(otherValue.Id);
            return typeMatches && valueMatches;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode() => Id.GetHashCode();

        /// <summary>
        /// Absolutes the difference.
        /// </summary>
        /// <param name="firstValue">The first value.</param>
        /// <param name="secondValue">The second value.</param>
        /// <returns>System.Int32.</returns>
        public static int AbsoluteDifference(Enumeration firstValue, Enumeration secondValue)
        {
            var absoluteDifference = Math.Abs(firstValue.Id - secondValue.Id);
            return absoluteDifference;
        }

        /// <summary>
        /// Froms the value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns>T.</returns>
        public static T FromValue<T>(int value) where T : Enumeration
        {
            var matchingItem = Parse<T, int>(value, "value", item => item.Id == value);
            return matchingItem;
        }

        /// <summary>
        /// Froms the display name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="displayName">The display name.</param>
        /// <returns>T.</returns>
        public static T FromDisplayName<T>(string displayName) where T : Enumeration
        {
            var matchingItem = Parse<T, string>(displayName, "display name", item => item.Name == displayName);
            return matchingItem;
        }

        /// <summary>
        /// Parses the specified value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="value">The value.</param>
        /// <param name="description">The description.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns>T.</returns>
        /// <exception cref="InvalidOperationException">'{value}' is not a valid {description} in {typeof(T)}</exception>
        private static T Parse<T, K>(K value, string description, Func<T, bool> predicate) where T : Enumeration
        {
            var matchingItem = GetAll<T>().FirstOrDefault(predicate);
            if (matchingItem == null) throw new InvalidOperationException($"'{value}' is not a valid {description} in {typeof(T)}");
            return matchingItem;
        }

        /// <summary>
        /// Compares to.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns>System.Int32.</returns>
        public int CompareTo(object other) => Id.CompareTo(((Enumeration)other).Id);
    }
}
 */


/*
 // ***********************************************************************
// Assembly         : XM.Evento.ConsultaGeneral.Application
// Author           : Pablo Restrepo
// Created          : 07-28-2020
//
// Last Modified By : Pablo Restrepo
// Last Modified On : 07-28-2020
// ***********************************************************************
// <copyright file="ColumnsEnum.cs" company="XM.Evento.ConsultaGeneral.Application">
//     Copyright (c) XianaApp S.A.S. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace XM.Evento.ConsultaGeneral.Application.Enumerations
{
    using System.Collections.Generic;

    /// <summary>
    /// Class ColumnsEnum.
    /// Implements the <see cref="Enumeration" />
    /// </summary>
    /// <seealso cref="Enumeration" />
    public class ColumnsEnum : Enumeration
    {
        /// <summary>
        /// The responsable nombre
        /// </summary>
        public static ColumnsEnum ResponsableNombre = new ColumnsEnum(1, "responsableNombre");
        /// <summary>
        /// The tipo
        /// </summary>
        public static ColumnsEnum Tipo = new ColumnsEnum(2, "tipo");
        /// <summary>
        /// The consecutivo
        /// </summary>
        public static ColumnsEnum Consecutivo = new ColumnsEnum(4, "consecutivo");
        /// <summary>
        /// The caso analisis identifier
        /// </summary>
        public static ColumnsEnum CasoAnalisisId = new ColumnsEnum(5, "casoAnalisisId");
        /// <summary>
        /// The descripcion
        /// </summary>
        public static ColumnsEnum DescripcionCorta = new ColumnsEnum(6, "descripcionCorta");

        /// <summary>
        /// The descripcion
        /// </summary>
        public static ColumnsEnum Descripcion = new ColumnsEnum(7, "descripcion");
        /// <summary>
        /// The fecha ocurrencia
        /// </summary>
        public static ColumnsEnum FechaOcurrencia = new ColumnsEnum(8, "fechaOcurrencia");

        /// <summary>
        /// The estado.
        /// </summary>
        public static ColumnsEnum Estado = new ColumnsEnum(9, "estado");
        /// <summary>
        /// The lecciones aprendidas ids
        /// </summary>
        public static ColumnsEnum LeccionesAprendidasIds = new ColumnsEnum(10, "leccionesAprendidasIdsCorto");
        /// <summary>
        /// The fecha creacion
        /// </summary>
        public static ColumnsEnum FechaCreacion = new ColumnsEnum(11, "fechaCreacion");
        /// <summary>
        /// The fecha maximum
        /// </summary>
        public static ColumnsEnum FechaMax = new ColumnsEnum(12, "fechaMax");
        /// <summary>
        /// The fecha publicacion
        /// </summary>
        public static ColumnsEnum FechaPublicacion = new ColumnsEnum(13, "fechaPublicacion");

        /// <summary>
        /// Initializes a new instance of the <see cref="ColumnsEnum"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        public ColumnsEnum(int id, string name) : base(id, name)
        {
        }

        public static IEnumerable<ColumnsEnum> List() => GetAll<ColumnsEnum>();
    }
}
 */



/*
 [TestMethod]
        [Owner("Pablo Restrepo")]
        public async Task GetAll_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();

            int esperado = 2;


            List<User> mockData = new List<User>
            {
                new User()
                {
                    Id=1,
                    FullName="Pablo Restrepo",
                    Nickname="pablortpo"
                },
                new User()
                {
                    Id=2,
                    FullName="Andrés Urango",
                    Nickname="andreurango"
                }
            };

            this.mockUserRepository.Setup(i => i.GetAll()).ReturnsAsync(mockData);


            // Act
            var result = await service.GetAll();

            // Assert
            Assert.AreEqual(esperado,result.Count);
            //this.mockRepository.VerifyAll();
        }
 */
