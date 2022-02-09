///*import React, { Component } from 'react';
  class Index extends React.Component {
    static displayName = Index.name;
    constructor(props) {
        super(props);
        this.state = { People: [], loading: true}
    }
    componentDidMount() {
        this.populatePersonData();
    }
    async populatePersonData() {
        const response = await fetch("/React/People");
        const data = await response.json();
        this.setState({ People: data, loading: false });
    }
    static renderPeopleTable(People) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Full Name</th>
<th>Action</th>
                    </tr>
                </thead>
                <tbody>
                    {
                        People.map(person =>
                            <tr key={person.PersonId}>
                                <td>{person.PersonId}</td>
                                <td>{person.FullName}</td>
                       <td>
    {/*<button className="btn btn-success" onClick = {(id) => this.handleDetail(person.PersonId)}>Detail</button>&nbsp;*/}
    <button className = "btn btn-danger" onClick ={(id) => this.handleDelete(person.PersonId)}>Delete</button>&nbsp;
    </td>
                        </tr>
                        )
                    }
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            :Index.renderPeopleTable(this.state.People);

        return (
            <div>
                <h1 id="tabelLabel" >Weather forecast</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
      }
      handleDelete(id:) {
        //if (!confirm("Do you want to delete person with Id: " + id))
        //    return;
        //else {
          fetch('/React/DeletePerson/' + id
            //  {
            //    method: 'DeletePerson'
            //}
            ).then(data => {
                this.setState(
                    {
                        People: this.state.People.filter((rec) => {
                            return (rec.PersonId != id);
                        })
                    });
            });
        }
   // }
}
//interface FetchPersonDataState {
//    empList: PersonData[];
//    loading: boolean;
//}

//export class FetchPerson extends React.Component<RouteComponentProps<{}>, FetchPersonDataState> {
//    constructor() {
//        super();
//        this.state = { empList: [], loading: true };

//        fetch('/React/People')
//            .then(response => response.json() as Promise<PersonData[]>)
//            .then(data => {
//                this.setState({ empList: data, loading: false });
//            });

//        // This binding is necessary to make "this" work in the callback  
//        this.handleDelete = this.handleDelete.bind(this);
//        this.handleEdit = this.handleEdit.bind(this);

//    }

//    public render() {
//        let contents = this.state.loading
//            ? <p><em>Loading...</em></p>
//            : this.renderPersonTable(this.state.empList);

//        return <div>
//            <h1>Employee Data</h1>
//            <p>This component demonstrates fetching Employee data from the server.</p>
//            <p>
//                <Link to="/AddPerson">Create New</Link>
//            </p>
//            {contents}
//        </div>;
//    }

//     //Handle Delete request for an employee  
//    private handleDelete(id: number) {
//        if (!confirm("Do you want to delete employee with Id: " + id))
//            return;
//        else {
//            fetch('/React/Delete/' + id, {
//                method: 'delete'
//            }).then(data => {
//                this.setState(
//                    {
//                        empList: this.state.empList.filter((rec) => {
//                            return (rec.employeeId != id);
//                        })
//                    });
//            });
//        }
//    }

//    private handleEdit(id: number) {
//        this.props.history.push("/React/EditPerson/" + id);
//    }

//     //Returns the HTML table to the render() method.  
//    private renderPersonTable(empList: PersonData[]) {
//        return <table className='table'>
//            <thead>
//                <tr>
//                    <th></th>
//                    <th>EmployeeId</th>
//                    <th>Name</th>
//                </tr>
//            </thead>
//            <tbody>
//                {empList.map(emp =>
//                    <tr key={emp.PersonId}>
//                        <td></td>
//                        <td>{emp.PersonId}</td>
//                        <td>{emp.FullName}</td>
//                        <td>
//                            <a className="action" onClick={(id) => this.handleEdit(emp.employeeId)}>Edit</a>  |
//                            <a className="action" onClick={(id) => this.handleDelete(emp.employeeId)}>Delete</a>
//                        </td>
//                    </tr>
//                )}
//            </tbody>
//        </table>;
//    }
//}

//export class PersonData {
//    PersonId: number = 0;
//    FullName: string = "";
//}



//class Table extends React.Component {
//    render() {
//        return (
//            <table>
//                <TableHeader />
//                <TableBody />
//            </table>
//        )
//        }
//}
//const TableHeader = () => {
//    return (
//        <thead>
//            <tr>
//                <th>ID</th>
//                <th>Full Name</th>
//            </tr>
//        </thead>
//    )
//}
//const TableBody = (props) => {
//    const rows = this.props.people.map(
//        person =>{
//        return (
//            <tbody>
//                <tr key={person.PersonId}>
//                    <td>{person.PersonId}</td>
//                <td>{person.FullName}</td>
//            </tr>
//            </tbody>
//        )
//    })

//    return <tbody>{rows}</tbody>
//}
//import Error from "~/ReactUtilities/Error.jsx";

//const sortAsc = 1;
//const sortDesc = -1;

//class PeopleTableRows extends React.Component {
//    render() {
//        return (
//            <tbody>
//                {
//                    this.props.people.map(
//                        person =>
//                            <tr key={person.PersonId}>
//                                <td>{person.PersonId}</td>
//                                <td>{person.FullName}</td>
//                               {/* <td><button className={"btn btn-outline-primary"} onClick={() => this.props.onPersonDetails(person.id)}>SHOW</button></td>*/}
//                            </tr>
//                    )
//                }
//            </tbody>
//        );
//    }
//}

//class PeopleTableHeader extends React.Component {
//    render() {
//        return (
//            <thead>
//                <tr>
//                    <th scope="col">ID</th>
//                    <th scope="col">FUll Name <button className={"btn btn-outline-dark btn-sm"} onClick={this.props.sortTable}>&#8645;</button></th>
//                    <th scope="col">Last Name</th>
//                    <th scope="col">Details</th>
//                </tr>
//            </thead>
//        );
//    }
//}

//class PeopleTable extends React.Component {
//    state = {
//        error: null,
//        isLoaded: false,
//        people: [],
//        sortDirection: 0
//    }

//    componentDidMount() {
//        // Fetch people
//         //Do some cool fetching here
//        fetch("/React/People")
//            .then(res => res.json())
//            .then(
//                (result) => {
//                    this.setState({
//                        isLoaded: true,
//                        people: result
//                    })
//                },
//                (error) => {
////                    this.setState({
////                        isLoaded: true,
////                        error
////                    })
////                }
////            );
////    }

////    sortTable = () => {
////        let sortDirection = sortAsc;
////        let columnToSort = 'FullName';

////        if (this.state.sortDirection === sortAsc) {
////            sortDirection = sortDesc;
////        }

////        this.state.people.sort((x1, x2) => x1[columnToSort] < x2[columnToSort] ? -1 * sortDirection : sortDirection);
////        this.setState({
////            sortDirection, people: this.state.people
////        });
////    }

////    render() {
////        const { error, isLoaded, people, sortDirection } = this.state;
////        if (error) {
////            return <Error message={error.message} />
////        } else if (!isLoaded) {
////            return <div>Loading...</div>
////        } else {
////            return (
////                <table className="table table-striped">
////                    <PeopleTableHeader sortTable={this.sortTable} />
////                    <PeopleTableRows />
////                </table>
////            );
////        }
////    }
////}
ReactDOM.render(<Index/>, document.getElementById('content'));

//import Details from "./PersonDetails.jsx";

//function PeopleList(props) {

//    const [people, setPeople] = React.useState([]);
//    const [languages, setLanguages] = React.useState([]);
//    const [cities, setCities] = React.useState([]);
//    const [searchText, setSearchText] = React.useState("");
//    const [selectedPerson, setSelectedPerson] = React.useState({});

//    const deletePerson = async (Id) => {
//        let data = await axios.delete("/React/People/" + selectedPerson.Id);

//        setPeople(people.filter(function (val, indx, arr) {
//            return val.Id !== Id
//        }));
//        setSelectedPerson(data);
//    }

//    const updatePersonDetails = async (Id) => {
//        try {

//            let data = await axios.get("/React/People/" + Id)
//                .then(({ data }) => data);
//            setSelectedPerson(data);
//        } catch (errors) {
//            console.log(errors);
//        }
//    }

//    const getLanguages = async () => {
//        try {
//            let data = await axios.get("/React/Languages").then(({ data }) => data);
//            setLanguages(data);
//        } catch (error) {

//        }
//    }

//    const getCities = async () => {
//        try {
//            let data = await axios.get("/React/Cities").then(({ data }) => data);
//            setCities(data);
//        } catch (error) {

//        }
//    }

//    const getPeople = async () => {
//        try {
//            let data = await axios.get("/React/People").then(({ data }) => data)
//            setPeople(data)
//        } catch (errors) {
//            console.error(errors);
//        }
//    }


//    React.useEffect(
//        () => {
//            getPeople()
//            getCities()
//            getLanguages()
//        }, []);

//    return (
//        <>
//            <div className="d-flex flex-wrap">
//                <Details person={selectedPerson} onDeletePerson={deletePerson} />
//            </div>
//            <div className="mt-2">
//                <input onChange={(e) => setSearchText(e.target.value)} className="form-control" type="text"
//                    placeholder="Filter by name" />
//            </div>
//            <table className="table table-hover">
//                <thead>
//                    <tr>
//                        <th scope="col">#</th>
//                        <th scope="col">Name</th>
//                        <th scope="col">Country</th>
//                        <th scope="col">City</th>
//                        <th scope="col">Phone</th>
//                        <th scope="col">Email</th>

//                    </tr>
//                </thead>
//                <tbody>
//                    {people.filter((person) => person.Name.includes(searchText)).map(person =>
//                        <tr style={{ cursor: "pointer" }} key={person.PersonId} onClick={() => updatePersonDetails(person.PersonId)}>
//                            <td>
//                                {person.Id}
//                            </td>
//                            <td>
//                                {person.Name}
//                            </td>
//                            <td>
//                                {person.CountryName}
//                            </td>
//                            <td>
//                                {person.CityName}
//                            </td>
//                            <td>
//                                {person.Phone}
//                            </td>
//                            <td>
//                                {person.Email}
//                            </td>
//                        </tr>
//                    )}
//                </tbody>
//            </table>
//        </>
//    )

//}

//export default PeopleList;