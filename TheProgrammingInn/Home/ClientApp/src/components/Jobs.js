import React, { Component } from 'react';
import {
    Row, Col
} from 'reactstrap';
import Job from './subcomponents/Job';

export class Jobs extends Component {
    displayName = Jobs.name

    //Constructor method
    //We update the state object with the properties from our List of Jobs. This will be an empty array for now.
    //we pull data from the API
    //isLoading is set to true and will be set to false once the data comes back from API
    constructor(props) {
        super(props);
        this.state = {
            jobs: [],
            isLoading: true
        }
    }

    //Calls the JobsController endpoint /api/jobs when the component is mounted in the DOM.
    //isLoading is set to false since the data is loaded.
    componentDidMount() {
        fetch('api/jobs')
            .then(response => response.json())
            .then(data => {
                this.setState({ jobs: data, isLoading: false })
            })
    }

    //Adds a spinner that indicates to the user that Jobs are loading. 
    //else clause will loop through the list of jobs and render a Job component from the subcomponents folder. 
    render() {
        if (this.state.isLoading) {
            return (<div className=" spinner-border image-center" style={{ width: '5rem', height: '5rem' }}> <div />{' '}</div>);
        }
        else {
            return (
                <div>
                    <Row>
                        {this.state.jobs.map(job =>
                            <Col md={6} key={job.id}>
                                <Job job={job} />
                            </Col>
                        )}
                    </Row>
                </div>
            );
        }
    }
};