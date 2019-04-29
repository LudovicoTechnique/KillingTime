using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class LoanFactory : MonoBehaviour
{
    [SerializeField] private GameObject _form;
    [SerializeField] private GameObject _canvas;
    [SerializeField] private GameObject _processor;

    private readonly List<string> _firstNames = new List<string>
    {
        "Armando",
        "Roger",
        "Penney",
        "Tonda",
        "Catina",
        "Katlyn",
        "Joelle",
        "Stephenie",
        "Shameka",
        "Doyle",
        "Dulcie",
        "Melanie",
        "Nicki",
        "Forrest",
        "Pok",
        "Marie",
        "Claude",
        "Charlena",
        "Lyle",
        "Jacinta",
        "Fransisca",
        "Millicent",
        "Kasie",
        "Tyson",
        "Andrew",
        "Raeann",
        "Tara",
        "Britt",
        "Virgie",
        "Susie",
        "Hang",
        "Eura",
        "Hillary",
        "Lizzette",
        "Renna",
        "Vern",
        "Coralie",
        "Yong",
        "Cori",
        "Jacquelin",
        "Pauline",
        "Gertha",
        "Phuong",
        "Frederica",
        "Madeline",
        "Levi",
        "Hollie",
        "Kathryn",
        "Geraldo",
        "Boyd",
        "Jewell",
        "Sonny",
        "Eugene",
        "Raphael",
        "Antonio",
        "Francisco",
        "Eldridge",
        "Michal",
        "Guadalupe"
    };

    private readonly List<string> _lastNames = new List<string>
    {
        "Diaz",
        "Blankenship",
        "Daugherty",
        "Mckinney",
        "Fuller",
        "Roth",
        "Rodriguez",
        "Yates",
        "Hickman",
        "Valenzuela",
        "Figueroa",
        "Nixon",
        "Norman",
        "Bonilla",
        "Blevins",
        "Rios",
        "Tyler",
        "Rosales",
        "Carson",
        "Lutz",
        "Dixon",
        "Snyder",
        "Washington",
        "Clements",
        "Fritz",
        "Whitaker",
        "Graves",
        "Ingram",
        "Welch",
        "Andrade",
        "Gregory",
        "Schmitt",
        "Day",
        "Miller",
        "Harmon",
        "Bryant",
        "Phillips",
        "Franklin",
        "Yang",
        "Ortega",
        "Lucas",
        "Forbes",
        "Pierce",
        "Walls",
        "Blackburn",
        "Craig",
        "Wilson",
        "Hendricks",
        "Salas",
        "Ferrell",
        "Miles",
        "Gallegos",
        "Kidd",
        "Sims",
        "Stephens",
        "Underwood",
        "Powell",
        "Benjamin",
        "Velez",
        "Sherman",
        "Park",
        "Benton",
        "Mckay"
    };

    public GameObject Player;
    
    private readonly List<string> _bodyFormatsCorrectWithName = new List<string>
    {
        "I, {name}, am requesting {amount}, because {reason}",
        "{name} here, I need {amount} because {reason}",
        "Requesting {amount} for the {name} account because {reason}",
        "This is {name} requesting a loan because {reason}",
        "I'm begging you, I, {name}, need {amount} as soon as possible because {reason}"
    }; 
    
    private readonly List<string> _bodyFormatsCorrectWithAmount = new List<string>
    {
        "I, {name}, am requesting {amount}, because {reason}",
        "{amount} needed because {reason}",
        "{name} here, I need {amount} because {reason}",
        "Requesting {amount} for the {name} account because {reason}",
        "Please, I really need {amount} as soon as possible because {reason}",
        "I'm begging you, I, {name}, need {amount} as soon as possible because {reason}"
    }; 
    
    private readonly List<string> _bodyFormatsCorrect = new List<string>
    {
        "I, {name}, am requesting {amount}, because {reason}",
        "{amount} needed because {reason}",
        "{name} here, I need {amount} because {reason}",
        "Requesting {amount} for the {name} account because {reason}",
        "Please, I really need {amount} as soon as possible because {reason}",
        "This is {name} requesting a loan because {reason}",
        "Requesting Loan because {reason}",
        "{reason}",
        "I'm desperate, I need a loan because {reason}",
        "I'm begging you, I, {name}, need {amount} as soon as possible because {reason}"
    }; 
    
    private readonly List<string> _bodyFormatsIncorrect = new List<string>
    {
        "I, {name}, am requesting {amount}.",
        "{amount} needed.",
        "Requesting {amount} for the {name} account.",
        "Please, I really need {amount} as soon as possible.",
        "Please, I'm desperate, I need {amount}.",
        "I'm begging you, I, {name}, need {amount} as soon as possible."
    }; 
    
    private readonly List<string> _reasons = new List<string>
    {
        "my husband is dying.",
        "I am dying.",
        "my wife is dying.",
        "rent is due.",
        "my kids are sick.",
        "I am sick.",
        "I am trying to move.",
        "I have debts.",
        "I want to start a business.",
        "I want a new car.",
        "there has been a death in the family.",
        "my house needs repairs.",
        "my time is running out."
    };

    private readonly List<char> _charecters = new List<char>
    {
        'a',
        'b',
        'c',
        'd',
        'e',
        'f',
        'h',
        'r',
        't',
        'y',
        'u',
        'i',
        'o',
        'p',
        's',
        'l',
        'n',
        'm'
    };
    
    /*
     0: No issue
     1: Name in body misspelled
     2: Expired
     3: Amount is too large
     4: Amount is inconsistant
     5: No reason
     */

    public void GenerateForm()
    {
        var newForm = Instantiate(_form, _canvas.transform);

        newForm.GetComponent<Form>().Acceptable = Random.Range(0, 9) >= 4;

        int issue = newForm.GetComponent<Form>().Acceptable ? 0 : Random.Range(0, 7) + 1;
        
        if (issue == 6)
            issue = 1;
        else if (issue == 7)
            issue = 2;

        newForm.GetComponent<Form>().Name =
            $"{_firstNames[Random.Range(0, _firstNames.Count)]} {_lastNames[Random.Range(0, _lastNames.Count)]}";

        newForm.GetComponent<Form>().SubmitBy = DateFormater.FormatDate(
            Player.GetComponent<Player>().Day + (issue == 2 ? 0 : Random.Range(0, 3)),
            issue == 2);
        

        newForm.GetComponent<Form>().Amount = issue == 3 ? 840 + Random.Range(1, 20) * 15 : Random.Range(1, 56) * 15;

        string bodyText;

        switch (issue)
        {
            case 1:
                bodyText = _bodyFormatsCorrectWithName[Random.Range(0, _bodyFormatsCorrectWithName.Count)];
                break;
            case 4:
                bodyText = _bodyFormatsCorrectWithAmount[Random.Range(0, _bodyFormatsCorrectWithAmount.Count)];
                break;
            case 5:
                bodyText = _bodyFormatsIncorrect[Random.Range(0, _bodyFormatsIncorrect.Count)];
                break;
            default:
                bodyText = _bodyFormatsCorrect[Random.Range(0, _bodyFormatsCorrect.Count)];
                break;
        }

        if (issue == 1)
        {
            if (Random.Range(0, 3) == 0)
                bodyText = bodyText.Replace("{name}", $"{_firstNames[Random.Range(0, _firstNames.Count)]} {_lastNames[Random.Range(0, _lastNames.Count)]}");
            else
            {
                var sb = new StringBuilder(newForm.GetComponent<Form>().Name);
                var randNum = Random.Range(1, sb.Length );
                bool notDone;
                do
                {
                    notDone = true;
                    if (sb[randNum] != ' ')
                    {
                        var randChar = _charecters[Random.Range(0, _charecters.Count)];
                        if (randChar != sb[randNum])
                        {
                            sb[randNum] = randChar;
                            bodyText = bodyText.Replace("{name}", sb.ToString());
                            notDone = false;
                        }
                    }
                } while (notDone);
            }
        }
        else
            bodyText = bodyText.Replace("{name}", newForm.GetComponent<Form>().Name);

        if (issue == 4)
        {
            bool wait = true;
            do
            {
                var fakeAmount = Random.Range(1, 56) * 15;
                if (fakeAmount != newForm.GetComponent<Form>().Amount)
                {
                    bodyText = bodyText.Replace("{amount}", TimeFormater.FormatTime(fakeAmount, Random.Range(0,3)));
                    wait = false;
                }
            } while (wait);
        }
        else
        {
            bodyText = bodyText.Replace("{amount}", TimeFormater.FormatTime(newForm.GetComponent<Form>().Amount, Random.Range(0,3)));
        }
        
        bodyText = bodyText.Replace("{reason}", _reasons[Random.Range(0, _reasons.Count)]);

        newForm.GetComponent<Form>().BodyText = bodyText;

        switch (issue)
        {
            case 0:
                newForm.GetComponent<Form>().FailureMessage = "There were no discrepancies.";
                break;
            case 1:
                newForm.GetComponent<Form>().FailureMessage = "Name was was inconsistent";
                break;
            case 2:
                newForm.GetComponent<Form>().FailureMessage = "Form had expired.";
                break;
            case 3:
                newForm.GetComponent<Form>().FailureMessage = "Amount requested exceeded 14 hours.";
                break;
            case 4:
                newForm.GetComponent<Form>().FailureMessage = "Amounts were inconsistent.";
                break;
            case 5:
                newForm.GetComponent<Form>().FailureMessage = "No reason was provided.";
                break;
        }
        newForm.GetComponent<Form>().SetValues();
        _processor.GetComponent<FormProcessor>().Form = newForm;
    }
}
