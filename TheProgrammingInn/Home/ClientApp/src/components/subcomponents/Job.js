import React, { Component } from 'react';
import {
    Row, Col, Card, CardImg, CardText, CardBody,
    CardTitle, CardSubtitle, Button
} from 'reactstrap';
import './Job.css';

function Job(props) {

    const job = props.job;

    return (
        <div className="job">
            <Card className="job-card">
                <CardBody>
                    <Row>
                        <Col md={7} sm={12}>
                            <CardImg className="company-logo center-mobile smaller-width" top width="100%" src={require('../../images/jobs/' + job.logo)} />
                        </Col>
                        <Col md={5} sm={12}>
                            <div className="center-job-info">
                                <CardTitle className="h4">{job.companyName}</CardTitle>
                                <CardSubtitle className="job-title">{job.jobTitle}</CardSubtitle>
                                <CardText>{job.startDate} – {job.endDate}</CardText>
                                <CardText className="job-location">{job.location}</CardText>
                            </div>
                        </Col>
                    </Row>
                    <h5 className="text-center">Job Duties</h5>
                    <ol>
                        {job.jobDuties.map(duty =>
                            <li key={duty}>{duty}</li>
                        )}
                    </ol>
                </CardBody>
            </Card>
        </div>
    );
}

export default Job;