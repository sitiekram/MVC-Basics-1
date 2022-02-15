﻿import Error from "./ReactUtilities/Error.jsx";

const sortAsc = 1;
const sortDesc = -1;

class PeopleTableRows extends React.Component {
    render() {
        return (
            <tbody>
                {
                    this.props.people.map(
                        person =>
                            <tr key={person.personId}>
                                <td>{person.personId}</td>
                                <td>{person.fullName}</td>
                                <td><button className={"btn btn-outline-primary"} onClick={() => this.props.onPersonDetails(person.personId)}>SHOW</button></td>
                            </tr>
                    )
                }
            </tbody>
        );
    }
}

class PeopleTableHeader extends React.Component {
    render() {
        return (
            <thead>
                <tr>
                    <th scope="col">ID</th>
                    <th scope="col">Full Name <button className={"btn btn-outline-dark btn-sm"} onClick={this.props.sortTable}>&#8645;</button></th>
                    <th scope="col">Details</th>
                </tr>
            </thead>
        );
    } 
}

class PeopleTable extends React.Component {
    state = {
        error: null,
        isLoaded: false,
        people: [],
        sortDirection: 0
    }
    componentDidMount() {
        fetch("/React/People")
            .then(res => res.json())
            .then(
                (result) => {
                    this.setState({
                        isLoaded: true,
                        people: result
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
    
    

    sortTable = () => {
        let sortDirection = sortAsc;
        let columnToSort = 'fullName';

        if (this.state.sortDirection === sortAsc) {
            sortDirection = sortDesc;
        }

        this.state.people.sort((x1, x2) => x1[columnToSort].toLowerCase() < x2[columnToSort].toLowerCase() ? -1 * sortDirection : sortDirection);
        this.setState({
            sortDirection, people: this.state.people
        });
    }

    render() {
        const { error, isLoaded, people} = this.state;
        if (error) {
            return <Error message={error.message} />
        } else if (!isLoaded) {
            return <div>Loading...</div>
        } else {
            return (
                <table className="table table-striped">
                    <PeopleTableHeader sortTable={this.sortTable} />
                    <PeopleTableRows onPersonDetails={this.props.onPersonDetails} people={people} />
                </table>
            );
        }
    }
}

export default PeopleTable;