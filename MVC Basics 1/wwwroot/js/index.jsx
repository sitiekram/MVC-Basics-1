const PersonTable = (props) => {
    const [persons, setPersons] = React.useState(props.persons)

    React.useEffect(() => {
        setPersons(props.persons)
    }, [props])

    return (
        <table className="table">
            <thead>
                <tr>
                    <th>Id</th>
                    <th className="btn btn-outline-secondary mb-1" onClick={() => { props.sort() }}>Name</th>
                    <th>Details</th>
                </tr>
            </thead>
            <tbody>
                {persons!= ' ' ? (
                    persons.map((item) => (
                        <tr key={item.id}>
                            <td>{item.id}</td>
                            <td >{item.name}</td>
                            <td>
                                <button onClick={() => { props.showDetails(item) }} className="btn btn-primary">Details</button>
                            </td>
                        </tr>
                    ))
                ) : (
                    <tr>
                        <td colSpan={3}>No persons</td>
                    </tr>
                )}
            </tbody>
        </table>
    )
}

function App() {

    const [error, setError] = React.useState(null);
    const [isLoaded, setIsLoaded] = React.useState(false);
    const [items, setItems] = React.useState([]);
    const [cities, setCities] = React.useState([]);
    const initialFormState = { id: null, name: '', cityName: '', languages: [] };
    const [currentPerson, setCurrentPerson] = React.useState(initialFormState);
    const [reRender, setReRender] = React.useState(0);
    const [sortOrder, setSortOrder] = React.useState("asc");

    const showDetails = (person) => {
        setCurrentPerson({ id: person.id, name: person.name, cityName: person.cityName, languages: person.languages });
    }

    function SortPersonList() {
        if (sortOrder === "asc") {
            items.sort((first, second) => {
                return first.name > second.name ? 1 : -1;
            });
            setSortOrder("dsc");
        }
        else {
            items.sort((first, second) => {
                return first.name > second.name ? -1 : 1;
            });
            setSortOrder("asc");
        }
    }

    React.useEffect(() => {
        GetPersons();
    }, [reRender])

    function GetPersons() {
        fetch("https://localhost:44301/react/getallpersons")
            .then(res => res.json())
            .then(
                (result) => {
                    setIsLoaded(true);
                    setItems(result.reactPersonVMList);
                    console.log(items);
                    setCities(result.citiesList);
                },
                (error) => {
                    setIsLoaded(true);
                    setError(error);
                }
            )
    }
    return (
        <div className="mt-3">
            <div className="mt-4">
                <h2>Person list</h2>
                <div>
                    <PersonTable persons={items} showDetails={showDetails} sort={SortPersonList} />
                </div>
            </div>
        </div>
    )
}
ReactDOM.render(<App />, document.getElementById('content'));


