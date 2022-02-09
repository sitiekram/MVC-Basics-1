////function Details(props) {
////    const [person, setPerson] = React.useState({});

////    const deletePerson = () => {
////        props.onDeletePerson(props.person.Id);
////        setPerson({});
////    }

////    return (
////        <div className="card" style={{ minWidth: "60rem" }} hidden={props.person.Id === undefined}>
////            <header className="card-header">
////                <div className="row">
////                    <h3 className="col">{props.person.Name}</h3>
////                    <div className="col-sm">

////                        <button className="text-right" onClick={() => deletePerson()}
////                            className="btn btn-danger outlined">Delete
////                        </button>
////                    </div>
////                </div>
////            </header>
////            <div className="card-body">
////                <div className="">
////                    <div className="row">
////                        <p className="card-text font-weight-bold col">Id:</p>
////                        <p className="card-text col">{props.person.Id}</p>
////                    </div>
////                    <div className="row">
////                        <p className="card-text font-weight-bold col">Name:</p>
////                        <p className="card-text col">{props.person.Name}</p>
////                    </div>
////                    <div className="row">
////                        <p className="card-text font-weight-bold col">Country:</p>
////                        <p className="card-text col">{props.person.CountryName}</p>
////                    </div>
////                    <div className="row">
////                        <p className="col card-text font-weight-bold">City:</p>
////                        <p className="col card-text ">{props.person.CityName}</p>
////                    </div>
////                </div>
////                <div className="row">
////                    <p className="col card-text font-weight-bold">
////                        Languages:
////                    </p>
////                    <ul className="col list-inline">

////                        {props.person.Languages !== undefined &&
////                            props.person.Languages.map(language =>
////                                <li className="list-inline-item" key={language}>{language}</li>
////                            )
////                        }
////                    </ul>
////                </div>
////            </div>
////        </div>
////    )

////}

////export default Details;


import Error from "./ReactUtilities/Error.jsx";

class DeletePersonButton extends React.Component {
    render() {
        return (
            <button className={"btn btn-danger"} onClick={() => this.props.onPersonDelete(this.props.PersonId)}>Delete Person</button>
        );
    }
}

class PersonDetailsTable extends React.Component {
    formatLanguages = (languages) => {
        let languagesString = "";
        languages.map(obj => languagesString += obj.language.name + " ");
        return languagesString.trim();
    }

    render() {
        const person = this.props.person;

        return (
            <table className="table">
                <thead>
                    <tr>
                        <th scope="col">ID</th>
                        <th scope="col">FUll Name</th>
                        <th scope="col">Phone Number</th>
                        <th scope="col">City</th>
                        <th scope="col">E-mail</th>
                        <th scope="col">Languages</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td scope="col">{person.PersonId}</td>
                        <td scope="col">{person.FullName}</td>
                        <td scope="col">{person.PhoneNumber}</td>
                        <td scope="col">{person.City.Name}</td>
                        <td scope="col">{person.Email}</td>
                        <td scope="col">{this.formatLanguages(person.languages)}</td>
                    </tr>
                </tbody>
            </table>
        );
    }
}

class PersonDetails extends React.Component {
    state = {
        isLoaded: false,
        error: null,
        person: null
    }

    componentDidMount() {
        // fetch full person details
        fetch("/React/Person/" + this.props.PersonId)
            .then(res => res.json())
            .then(
                (result) => {
                    this.setState({
                        isLoaded: true,
                        person: result
                    })
                },
                (error) => {
                    this.setState({
                        isLoaded: true,
                        error
                    })
                }
            );
    }

    render() {
        const { error, isLoaded, person } = this.state;
        if (error) {
            return <Error message={error.message} />
        }
        else if (!isLoaded) {
            return <div>Loading Person...</div>
        } else {
            return (
                <div>
                    <PersonDetailsTable person={person} />
                    <DeletePersonButton onPersonDelete={this.props.onPersonDelete} PersonId={person.PersonId} />
                </div>
            );
        }
    }
}

export default PersonDetails;
