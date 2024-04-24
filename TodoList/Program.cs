var todoList = new List<string>();

Console.WriteLine("Welcome to your TODO list manager!");

bool shallExit = false;
// this variable will only be true if the user selects the '[E]xit' option;
// while false, the program will function in a loop

while (!shallExit)
{
    Console.WriteLine();
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("[S]ee all TODOs");
    Console.WriteLine("[A]dd a TODO");
    Console.WriteLine("[R]emove a TODO");
    Console.WriteLine("[E]xit");
    var userChoice = Console.ReadLine();
    switch (userChoice)
    {
        case "S":
        case "s":
            SeeAllTodos();
            break;
        case "A":
        case "a":
            AddTodo();
            break;
        case "R":
        case "r":
            RemoveTodo();
            break;
        case "E":
        case "e":
            shallExit = true;
            break;
        default:
            Console.WriteLine("Invalid input!");
            break;
    }
}

// if the list is not empty, this method shows all the TODOs that have been added,
// with the elements starting with index 1
void SeeAllTodos()
{
    if (todoList.Count == 0)
    {
        ShowNoTodosMessage();
        return;
    }
    else
    {
        for (int i = 0; i < todoList.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {todoList[i]}");
        }
    }
}

// this method keeps asking the user to provide a TODO description until
// it meets the requirements set in the IsDescriptionValid method; if the
// description is valid, it will be added into the list
void AddTodo()
{
    string userDescription;
    do
    {
        Console.WriteLine("Enter the TODO description:");
        userDescription = Console.ReadLine();
    }
    while (!IsDescriptionValid(userDescription));

    todoList.Add(userDescription);

}

// this method checks if the TODO description given by the user is not
// empty and if it hasn't given before, that is, it is a unique one;
// if these requirements are met, the description is set as valid
bool IsDescriptionValid(string userDescription)
{
    if (userDescription == "")
    {
        Console.WriteLine("The description cannot be empty.");
        return false;
    }
    if (todoList.Contains(userDescription))
    {
        Console.WriteLine("The description must be unique.");
        return false;
    }
    return true;
}

// this method checks if the list is not empty; if not, it shows its elements
// and keeps asking the user to provide the index of the TODO that will be removed
// until the TryReadIndex method returns true
void RemoveTodo()
{
    if (todoList.Count == 0)
    {
        ShowNoTodosMessage();
        return;
    }
    int index;
    do
    {
        Console.WriteLine("Select the index of the TODO you want to remove.");
        SeeAllTodos();
    } while (!TryReadIndex(out index));

    RemoveTodoAtIndex(index - 1);
}

// this method tries to read the given index to remove a certain TODO;
// if the input is empty, it will return false; if it can be parsed as
// an integer, it will return true if the index is larger or equal to 1 
// and if it is smaller or equal to the count of elements from the list;
// if it cannot be parsed as an integer, it will also return false
bool TryReadIndex(out int index)
{
    var selectedIndex = Console.ReadLine();
    if (selectedIndex == "")
    {
        index = 0;
        Console.WriteLine("Selected index cannot be empty");
        return false;
    }
    if (int.TryParse(selectedIndex, out index) &&
       index >= 1 &&
       index <= todoList.Count)
    {
        return true;
    }
    Console.WriteLine("The given index is not valid.");
    return false;
}

// this method removes the TODO with the given index and shows
// its description
void RemoveTodoAtIndex(int index)
{
    var todoToBeRemoved = todoList[index];
    todoList.RemoveAt(index);
    Console.WriteLine("TODO removed: " + todoToBeRemoved);

}



// this method simply prints a message that there are no TODOs in the list
static void ShowNoTodosMessage()
{
    Console.WriteLine("No TODOs have been added yet.");
}
