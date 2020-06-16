namespace client.Controller.Validators
{
    public class MovieValidator
    {
        public bool ValidateMovie(string title, string genre, string actors)
        {
            bool ok = true;
            System.Text.RegularExpressions.Regex rTitle = new System.Text.RegularExpressions.Regex(@"[a-zA-Z]+");
            //System.Text.RegularExpressions.Regex rCnp = new System.Text.RegularExpressions.Regex(@"[0-9]{13}");

            if (!rTitle.IsMatch(title) || !(title.Length > 0))
            {
                ok = false;
            }
            if (!rTitle.IsMatch(genre) || !(genre.Length > 0))
            {
                ok = false;
            }
            if (!rTitle.IsMatch(actors) || !(actors.Length > 0))
            {
                ok = false;
            }

            return ok;
        }

        public bool ValidateMovieTitleGenreOrActors(string valid)
        {
            System.Text.RegularExpressions.Regex rValid = new System.Text.RegularExpressions.Regex(@"[a-zA-Z]+");
            if (rValid.IsMatch(valid))
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
