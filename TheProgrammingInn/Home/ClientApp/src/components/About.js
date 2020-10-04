import React, { Component } from 'react';
//Update the name for this logo.
import logo from '../images/about/default-avatar.png';
import {
    Row, Col, Card, CardImg, CardText, CardBody,
    CardTitle, CardSubtitle, Button
} from 'reactstrap';

//export class component to use in other components
export class About extends Component {
    displayName = About.name

    //Constructor method
    //We update the state object with the properties from our About object. These are empty strings for now until
    //we pull data from the API
    constructor(props) {
        super(props);
        this.state = {
            name: "",
            title: "",
            location: "",
            description: ""
        }
    }

    //This method is triggered when the About component "mounts", meaning it's available to the DOM.
    //fetch will call the API endpoint we created in the previous steps
    //data contains our data from about.json. Each property in the State object is loaded with this data.
    componentDidMount() {
        fetch('api/about')
            .then(response => response.json())
            .then(data => {
                this.setState({
                    name: data.name,
                    title: data.title,
                    location: data.location,
                    description: data.description
                })
            })
    }

    //render is required in the class Component. This will load JSX code on the DOM. 
    //Row and Col is basic bootstrap, it's just using as a component in React instead of your typical css class.
    //Here we are adding our About information. As a bonus, we are adding icons and links for linkedin, github, and email.
    render() {
        return (
            <div style={{ padding: "15px"}}>
                <Row>
                    <Col md={2}>
                        <img style={{ height: "100px" }} src={logo} />
                    </Col>
                    <Col md={3} className="center-mobile-text">
                        <div >
                            <h5>{this.state.name}</h5>
                            <p>{this.state.location}</p>
                        </div>
                        <a style={{ color: "#007bb5" }} target="_blank" href="https://www.linkedin.com">
                            <span className="fa-stack fa-lg">
                                <i className="fas fa-circle fa-stack-2x"></i>
                                <i className="fab fa-linkedin-in fa-stack-1x fa-inverse"></i>
                            </span>
                        </a>
                        <a style={{ color: "black" }} target="_blank" href="https://github.com/">
                            <span className="fa-stack fa-lg">
                                <i className="fas fa-circle fa-stack-2x"></i>
                                <i className="fab fa-github fa-stack-1x fa-inverse"></i>
                            </span>
                        </a>
                        <a style={{ color: "red" }} target="_blank" href="mailto:GeorgeK@gmail.com">
                            <span className="fa-stack fa-lg">
                                <i className="fas fa-circle fa-stack-2x"></i>
                                <i className="fas fa-envelope fa-stack-1x fa-inverse"></i>
                            </span>
                        </a>
                    </Col>
                    <Col md={7}>
                        <p className="textStyle">{this.state.description}</p>
                    </Col>
                </Row>
            </div>
        )
    }
};