import Error from "./ReactUtilities/Error.jsx";

class GenderSelect extends React.Component {
    render() {
        return (
            <select id={this.props.id} name={this.props.name} className={"form-select"} onChange={this.props.onChange} required>
                <option value={""}>Select</option>
                {
                    this.props.genders.map(PhoneNumber =>
                        <option key={PhoneNumber} value={PhoneNumber}>{PhoneNumber}</option>
                    )
                }
            </select>
        );
    }
}

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
            FullName: '',
            PhoneNumber: '',
            countryId: -99,
            cityId: -99,
            Email: ''
        }

        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleFullNameChange = this.handleFullNameChange.bind(this);
        this.handlePhoneNumberChange = this.handlePhoneNumberChange.bind(this);
        this.handleCountryChange = this.handleCountryChange.bind(this);
        this.handleCityChange = this.handleCityChange.bind(this);
        this.handleEmailChange = this.handleEmailChange.bind(this);
    }

    handleFullNameChange(e) {
        this.setState({ FullName: e.target.value });
    }
    handlePhoneNumberChange(e) {
        this.setState({ PhoneNumber: e.target.value });
    }
    handleCountryChange(e) {
        this.setState({ countryId: e.target.value });
        // TODO: Change cities based on country selection
    }
    handleCityChange(e) {
        this.setState({ cityId: e.target.value });
    }
    handleEmailChange(e) {
        this.setState({ Email: e.target.value });
    }

    handleSubmit(e) {
        e.preventDefault();

        const { FullName, PhoneNumber, countryId, cityId, Email } = this.state;

        this.props.onSubmit({
            FullName: FullName,
            PhoneNumber: PhoneNumber,
            countryId: countryId,
            cityId: cityId,
            Email: Email
        });

        e.target.reset();
    }

    render() {
        return (
            <div className={"container"}>
                <form onSubmit={this.handleSubmit}>
                    <div className={"mb-3"}>
                        <label htmlFor={"FullName"}>First Name</label>
                        <input id={"FullName"} name={"FullName"} type={"text"} className={"form-control"} onChange={this.handleFullNameChange} maxLength={20} required />
                    </div>
                    <div className={"mb-3"}>
                        <label htmlFor={"PhoneNumber"}>PhoneNumber</label>
                        <PhoneNumberSelect id={"PhoneNumber"} name={"PhoneNumber"} PhoneNumbers={this.props.data.PhoneNumbers} onChange={this.handlePhoneNumberChange} />
                    </div>
                    <div className={"mb-3"}>
                        <label htmlFor={"countryId"}>Country</label>
                        <DataSelect id={"countryId"} name={"countryId"} data={this.props.data.countries} onChange={this.handleCountryChange} />
                    </div>
                    <div className={"mb-3"}>
                        <label htmlFor={"cityId"}>City</label>
                        <DataSelect id={"cityId"} name={"cityId"} data={this.props.data.cities} onChange={this.handleCityChange} />
                    </div>
                    <div className={"mb-3"}>
                        <label htmlFor={"Email"}>E-mail</label>
                        <input id="Email" name={"Email"} type={"Email"} className={"form-control"} placeholder={"name@example.com"} onChange={this.handleEmailChange} maxLength={255} required />
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
        data.append('FullName', person.FullName);
        data.append('Gender', person.gender);
        data.append('CountryId', person.countryId)
        data.append('CityId', person.cityId);
        data.append('Email', person.Email);

        fetch("/React/CreatePerson",
            { method: "PUT", body: data })
            .then(() => this.setState({ status: 'Created person successfully' }));

        // clear form?
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