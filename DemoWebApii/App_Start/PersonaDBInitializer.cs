using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DemoWebApii.Models;

namespace DemoWebApii.App_Start
{
    public class PersonaDBInitializer: DropCreateDatabaseAlways<PersonaDBContext>
    {
        protected override void Seed(PersonaDBContext context)
        {
            var personas = new List<Persona>
            {
                new Persona { nombre = "Julio", ApPaterno = "Avellaneda", Twitter = "@julitogtu"},
                new Persona { nombre = "Juan", ApPaterno = "Ruiz", Twitter = "@juankruiz"},
                new Persona { nombre = "Roberto", ApPaterno = "Alvarado", Twitter = "@ralvaradot"},
                new Persona { nombre = "Nicolas", ApPaterno = "Herrera", Twitter = "@nicolocodev"},
                new Persona { nombre = "Jorge", ApPaterno = "Ramirez", Twitter = "@jramirezdev"},
                new Persona { nombre = "Nelson", ApPaterno = "Venegas", Twitter = "@nvenegar"}

            };
            personas.ForEach(c => context.Persona.Add(c));
            context.SaveChanges();
        }
    }
}