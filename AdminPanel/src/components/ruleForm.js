import React, { Component } from 'react';
import DateTimePicker from 'react-datetime-picker';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { addNewRuleAction } from '../actions/index';

class RuleForm extends Component {
    constructor(props) {
        super(props);

        this.state = {
            rule: {
                title: '',
                description: '',
                rate: 1,
                version: 1,
                priority: 1,
                expiresDaysAfter: 0,
                fromDate: new Date(),
                toDate: new Date()
            }
        };

        this.onDateFromChange = this.onDateFromChange.bind(this);
        this.onDateToChange = this.onDateToChange.bind(this);
        this.onFormSubmit = this.onFormSubmit.bind(this);
        this.onInputChange = this.onInputChange.bind(this);
    }

    render() {
        return (
            <form className='row jumbotron' onSubmit={this.onFormSubmit} >
                <div className="form-group col-md-3">
                    <label>Title</label>
                    <input id="title" value={this.state.rule.title} onChange={this.onInputChange} className="form-control" />
                </div>
                <div className="form-group col-md-3">
                    <label>Description</label>
                    <input id="description" value={this.state.rule.description} onChange={this.onInputChange} className="form-control" />
                </div>
                <div className="form-group col-md-3">
                    <label>Rate</label>
                    <input id="rate" value={this.state.rule.rate} onChange={this.onInputChange} className="form-control" />
                </div>
                <div className="form-group col-md-3">
                    <label>Version</label>
                    <input id="version" value={this.state.rule.version} onChange={this.onInputChange} className="form-control" />
                </div>
                <div className="form-group col-md-3">
                    <label>Expires After Days</label>
                    <input id="expiresDaysAfter" value={this.state.rule.expiresDaysAfter} onChange={this.onInputChange} className="form-control" />
                </div>
                <div className="form-group col-md-3">
                    <label>Priority</label>
                    <input id="priority" value={this.state.rule.priority} onChange={this.onInputChange} className="form-control" />
                </div>
                <div className="form-group col-md-3">
                    <label>From Date</label>
                    <DateTimePicker
                        value={this.state.rule.fromDate}
                        onChange={this.onDateFromChange} className="form-control"
                    />
                </div>
                <div className="form-group col-md-3">
                    <label>To Date</label>
                    <DateTimePicker
                        value={this.state.rule.toDate}
                        onChange={this.onDateToChange} className="form-control"
                    />
                </div>
                <button type="submit" className="btn btn-success col-md-3">Save</button>
            </form>
        )
    }

    onDateFromChange = function (date) {
        this.setState(prevState => ({
            rule: {
                ...prevState.rule, fromDate: date
            }
        }));
    }

    onDateToChange = function (date) {
        this.setState(prevState => ({
            rule: {
                ...prevState.rule, toDate: date
            }
        }));
    }
    onFormSubmit = function (event) {
        event.preventDefault();
        this.props.saveRule(this.state.rule)
    }
    onInputChange = function (event) {
        let prevState = this.state.rule;
        this.setState({ rule: { ...prevState, [event.target.id]: event.target.value } });
    }

}


function mapDispatchToProps(dispatch) {
    return bindActionCreators({ saveRule: addNewRuleAction }, dispatch);
}

export default connect(null, mapDispatchToProps)(RuleForm);