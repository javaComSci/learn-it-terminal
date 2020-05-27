import React, { Component } from 'react';
import { Button } from '@material-ui/core';
import ImportWordDialog from './ImportWordDialog';
import ViewWordsDialog from './ViewWordsDialog';

export default class MenuButtons extends Component {
    constructor(props) {
        super(props);
        this.state = {

        };
    }

    render() {
        return <div>
            <ImportWordDialog />
            <div style={{padding: 10}}> </div>
            <ViewWordsDialog />
        </div>
    }
}
