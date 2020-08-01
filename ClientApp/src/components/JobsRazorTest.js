import React, {Component} from 'react'
import {Details} from '../components/JobView/Details.cshtml'

export class JobsRazorTest extends Component {
    static displayName = JobsRazorTest.name;
    
    render() {
        return(
            <div>
                {Details}
            </div>
        )
    }
}

