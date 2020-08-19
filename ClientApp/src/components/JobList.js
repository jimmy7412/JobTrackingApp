import React, {Component} from 'react';

export class JobList extends Component {
    static displayName = JobList.name;

    constructor(props) {
        super(props);
        this.state = { jobs: [], loading: true };
    }

    componentDidMount() {
        this.populateJobsData();
    }

    static renderJobsTable(jobs) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                <tr>
                    <th>Company</th>
                    <th>Title</th>
                    <th>jobNumber</th>
                    <th>Last Checked</th>
                </tr>
                </thead>
                <tbody>
                {jobs.map(jobs =>
                    <tr key={jobs.ID}>
                        <td>{jobs.company}</td>
                        <td>{jobs.title}</td>
                        <td>{jobs.jobnumber}</td>
                        <td>{jobs.last_checked}</td>
                    </tr>
                )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = /*this.state.loading
            ? <p><em>Loading...</em></p>
            :*/ JobList.renderJobsTable(this.state.jobs);

        return (
            <div>
                <h1 id="tableLabel" >Weather forecast</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }

    async populateJobsData() {
        const response = await fetch('JobView');
        const data = await response.json();
        this.setState({ jobs: data, loading: false });
    }
}
