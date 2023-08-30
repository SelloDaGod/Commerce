import React, { Component } from 'react';
import { Container, Row, } from 'react-bootstrap';
import axios from 'axios';
import {useState} from 'react';
export class Home extends Component {
     
    constructor(props) {
        super(props);
        this.state = {
            categories: []
        };
    }
  //send request to api for categories
  //render categories in component

    componentDidMount() {
       
        axios.get('https://localhost:7093/categories', { headers: { 'Content-Type': 'application/json' } })
            .then(response => {
                this.setState({ categories: response.data });
            })
            .catch(error => {
                console.error('Error fetching data:', error);
            });

    }
    render() {
        const { categories } = this.state;
    return (
      <div>
        <h1>Commerce</h1>
       
            <Container>

                    {categories.map(category => (
                        <Row key={category.id}>
                            <div>{category.name}</div>
                        </Row>
                    ))}
                </Container>
            </div>
        );
    }
}



