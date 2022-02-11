import Error from "./ReactUtilities/Error.jsx";

class DeletePersonButton extends React.Component { 
    render() {
        return (
            <button className={"btn btn-danger"} onClick={() => this.props.onPersonDelete(this.props.personID)}>Delete Person</button>
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
                        <th scope="col">Full Name</th>
                        <th scope="col">Country</th>
                        <th scope="col">City</th>
                        <th scope="col">E-mail</th>
                        <th scope="col">Phone Number</th>
                        <th scope="col">Languages</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td scope="col">{person.personId}</td>
                        <td scope="col">{person.fullName}</td>
                        <td scope="col">{person.city.country.name}</td>
                        <td scope="col">{person.city.name}</td>
                        <td scope="col">{person.email}</td>
                        <td scope="col">{person.phoneNumber}</td>
                        <td scope="col">{this.formatLanguages(person.peopleLanguages)}</td>
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
        fetch("/React/Person/" + this.props.personID)
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
                    <DeletePersonButton onPersonDelete={this.props.onPersonDelete} personID={person.personId} />
                </div>
            );
        }
    }
}

export default PersonDetails;
