import Error from "./ReactUtilities/Error.jsx";
class DataSelect extends React.Component {
    render() {
        return (
            <select id={this.props.id} name={this.props.name} className={"form-select"} onChange={this.props.onChange} required>
                <option value={""}>Select</option>
                {
                    this.props.data.map(item =>
                        <option key={item.id} value={item.id}>{item.name}</option>
                    )
                }
            </select>
        );
    }
}

class PersonCreateForm extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            fullName: '',
            phoneNumber: '',
            //countryId: -99,
            cityId: -99,
            email: ''
        }

        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleFullNameChange = this.handleFullNameChange.bind(this);
        this.handlePhoneNumberChange = this.handlePhoneNumberChange.bind(this);
        this.handleCityChange = this.handleCityChange.bind(this);
        this.handleEmailChange = this.handleEmailChange.bind(this);
    }

    handleFullNameChange(e) {
        this.setState({ fullName: e.target.value });
    }
    handlePhoneNumberChange(e) {
        this.setState({ phoneNumber: e.target.value });
    }
    handleCityChange(e) {
        this.setState({ cityId: e.target.value });
    }
    handleEmailChange(e) {
        this.setState({ email: e.target.value });
    }

    handleSubmit(e) {
        e.preventDefault();

        const { fullName, phoneNumber, cityId, email } = this.state;

        this.props.onSubmit({
            fullName: fullName,
            phoneNumber: phoneNumber,
            //countryId: countryId,
            cityId: cityId,
            email: email
        });

        e.target.reset();
    }

    render() {
        return (
            <div className={"container"}>
                <form onSubmit={this.handleSubmit}>
                    <div className={"mb-3"}>
                        <label htmlFor={"fullName"}>First Name</label>
                        <input id={"fullName"} name={"fullName"} type={"text"} className={"form-control"} onChange={this.handleFullNameChange} maxLength={20} required />
                    </div>
                    <div className={"mb-3"}>
                        <label htmlFor={"phoneNumber"}>Phone Number</label>
                        <input id="phoneNumber" name={"phoneNumber"} type={"text"} className={"form-control"}  onChange={this.handlePhoneNumberChange} maxLength={15} required />
                    </div>
                    <div className={"mb-3"}>
                        <label htmlFor={"cityId"}>City</label>
                        <DataSelect id={"cityId"} name={"cityId"} data={this.props.data.cities} onChange={this.handleCityChange} />
                    </div>
                    <div className={"mb-3"}>
                        <label htmlFor={"email"}>E-mail</label>
                        <input id="email" name={"email"} type={"email"} className={"form-control"} placeholder={"name@example.com"} onChange={this.handleEmailChange} maxLength={255} required />
                    </div>
                    <div className={"mb-3"}>
                        <button type={"submit"} className={"mb-3 btn btn-primary"}>Create Person</button>
                    </div>

                </form>
            </div>
        );
    }
}

class PersonCreate extends React.Component {
    state = {
        isLoaded: false,
        error: null,
        data: [],
        status: null
    }

    componentDidMount() {
        fetch("/React/GetFormData")
            .then(res => res.json())
            .then(
                (result) => {
                    this.setState({
                        isLoaded: true,
                        data: result
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

    handlePersonSubmit = (person) => {
        const data = new FormData();
        data.append('FullName', person.fullName);
        data.append('PhoneNumber', person.phoneNumber);
        data.append('CityId', person.cityId);
        data.append('Email', person.email);

        fetch("/React/CreatePerson",
            { method: "PUT", body: data })
            .then(() => this.setState({ status: 'Created person successfully' }));
    }

    render() {
        const { isLoaded, error, data, status } = this.state;

        let statusBox = null;

        if (status) {
            statusBox = <div className="p-3 mb-2 bg-success text-white">{this.state.status}</div>
        }

        if (error) {
            return <Error message={error.message} />
        } else if (!isLoaded) {
            return <div>Loading...</div>
        } else {
            return (
                <div>
                    {statusBox}
                    <PersonCreateForm data={data} onSubmit={this.handlePersonSubmit} />
                </div>
            );
        }
    }
}

export default PersonCreate;