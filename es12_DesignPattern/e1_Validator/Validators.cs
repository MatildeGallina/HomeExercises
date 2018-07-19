using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e1_Validator
{
    /* ### 1.1 - Validatori con TEMPLATE
     * 
     * Bisogna creare dei validatori, in modo che istanze della classe `Person` siano controllate prima di essere
     * salvate sul database.
     * 
     * Ogni validatore funziona così: ha un metodo `Validate` che prende in input una `Person`, e fa il suo controllo.
     * Se il controllo riesce, il metodo esce.
     * Altrimenti, restituisce una lista di errori (ogni errore è una stringa).
     * 
     * I validatori sono:
     * - `IdValid` (l'`Id` non può essere negativo)
     * - `NameNotEmpty` (il `Name` non può essere null o stringa blank),
     * - `BirthInRange` (la data di nascita non può essere fuori dal range 1900 - 2017)
     * 
     * I validatori vanno realizzati col pattern TEMPLATE.
     */

    public abstract class BaseValidator
    {
        public  List<string> Validate(Person p)
        {
            var errors = new List<string>();

            if (IsNotValid(p))
                errors.Add(ErrorMessage());

            return errors;
        }

        internal abstract bool IsNotValid(Person p);
        internal abstract string ErrorMessage();
    }

    public class IdValidValidator : BaseValidator
    {
        internal override bool IsNotValid(Person p)
        {
            return p.Id <= 0;
        }

        internal override string ErrorMessage()
        {
            return "Id not valid!";
        }
    }

    public class NameNotEmptyValidator : BaseValidator
    {
        internal override bool IsNotValid(Person p)
        {
            return string.IsNullOrWhiteSpace(p.Name);
        }

        internal override string ErrorMessage()
        {
            return "Name not valid!";
        }
    }

    public class BirthInRangeValidator : BaseValidator
    {
        internal override bool IsNotValid(Person p)
        {
            return (p.Birth.Year < 1900 || p.Birth.Year > 2017);
        }

        internal override string ErrorMessage()
        {
            return "Birth not valid!";
        }
    }

    /* ### 1.2 Validatori con COMPOSITE
     * 
     * Per validare la proprietà Address, bisogna usare un validatore `AddressValidator` _composto_.
     * Esporrà un metodo pubblico `Validate` come gli altri validatori, ma dentro avrà una lista di
     * validatori privati per validare tutte le proprietà di Address:
     * - `AddressNotNull` (l'intero oggetto `Address` non può essere null sulla `Person`)
     * - `StreetNotEmpty` (la strada non può essere stringa blank)
     * - `ZipValid` (il numero deve avere 5 cifre)
     */

    public class AddresValidator
    {
        public AddresValidator(List<BaseValidator> baseValidators)
        {
            _baseValidators = new List<BaseValidator>
                {
                    new AddressNotNullValidator(),
                    new StreetNotEmptyValidator(),
                    new ZipValidValidator(),
                };
        }
        private List<BaseValidator> _baseValidators { get; set; }

        public List<string> Validate(Person p)
        {
            var errors = new List<string>();

            foreach(var validator in _baseValidators)
                if (validator.IsNotValid(p))
                    errors.Add(validator.ErrorMessage());

            return errors;
        }
    }

    public class AddressNotNullValidator : BaseValidator
    {
        internal override bool IsNotValid(Person p)
        {
            return p.Address == null;
        }

        internal override string ErrorMessage()
        {
            return "Address not valid";
        }
    }

    public class StreetNotEmptyValidator : BaseValidator
    {
        internal override bool IsNotValid(Person p)
        {
            return string.IsNullOrWhiteSpace(p.Address.Street);
        }

        internal override string ErrorMessage()
        {
            return "Street not valid!";
        }
    }

    public class ZipValidValidator : BaseValidator
    {
        internal override bool IsNotValid(Person p)
        {
            return string.IsNullOrWhiteSpace(p.Address.ZIP) ||
                p.Address.ZIP.Length != 5 ||
                !p.Address.ZIP.All(l => char.IsNumber(l));
        }

        internal override string ErrorMessage()
        {
            return "ZIP not valid!";
        }
    }

    /* ### 1.3 Validatori con Factory
     * 
     * Per creare la lista di Validatori da usare, bisogna implementare un **Factory Method** che prende in
     * input una lista di stringhe con i nomi dei validatori (es: `"IdValid"`, `"BirthInRange"`), e restituisce
     * una lista coi Validatori voluti. Per implementare il factory method non fare uno switch sul valore della
     * stringa: usare invece **Reflection** per costruire l'istanza di una classe dato il suo nome.
     * 
     */

    class Factory
    {
        public List<BaseValidator> CreateList(List<string> inputList)
        {
            var validatorList = new List<BaseValidator>();

            foreach(var v in inputList)
            {
                foreach()
            }
        }
    }
}
