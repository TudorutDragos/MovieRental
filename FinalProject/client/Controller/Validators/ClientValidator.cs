namespace client.Controller.Validators
{
    public class ClientValidator
    {

        public bool ValidateClient(string cnp, string firstName, string lastName, string address)
        {
            bool ok = true;
            System.Text.RegularExpressions.Regex rName = new System.Text.RegularExpressions.Regex(@"[a-zA-Z]+");
            System.Text.RegularExpressions.Regex rCnp = new System.Text.RegularExpressions.Regex(@"[0-9]{13}");
            System.Text.RegularExpressions.Regex rAddress = new System.Text.RegularExpressions.Regex(@"[a-zA-Z0-9 ]+");

            if (!rName.IsMatch(firstName) || !(firstName.Length > 0))
            {
                ok = false;
            }
            if (!rName.IsMatch(lastName) || !(lastName.Length > 0))
            {
                ok = false;
            }
            if (!rCnp.IsMatch(cnp))
            {
                ok = false;
            }
            if (!rAddress.IsMatch(address) || !(address.Length > 0))
            {
                ok = false;
            }
            return ok;
        }

        public bool ValidateClientCnp(string cnp)
        {
            System.Text.RegularExpressions.Regex rCnp = new System.Text.RegularExpressions.Regex(@"[0-9]{13}");
            if (rCnp.IsMatch(cnp))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
