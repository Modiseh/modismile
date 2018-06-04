import React, { Component } from 'react';
import DateTimePicker from 'react-datetime-picker';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { addNewRuleAction } from '../actions/index';
import currentRule from '../reducers/currentRule_Reducer';

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
                expiresAfterDays: 0,
                dateFrom: new Date(),
                dateTo: new Date()
            }
        };

        this.state.rule = this.props.currentRule;

        this.onDateFromChange = this.onDateFromChange.bind(this);
        this.onDateToChange = this.onDateToChange.bind(this);
        this.onFormSubmit = this.onFormSubmit.bind(this);
        this.onInputChange = this.onInputChange.bind(this);
    }

    onDateFromChange = function (date) {
        this.setState(prevState => ({
            rule: {
                ...prevState.rule, dateFrom: date
            }
        }));
    }

    onDateToChange = function (date) {
        this.setState(prevState => ({
            rule: {
                ...prevState.rule, dateTo: date
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

    componentWillReceiveProps(nextProps) {
        if (nextProps.currentRule !== this.props.currentRule) {
            this.setState({ rule: nextProps.currentRule });
        }
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
                    <input id="expiresAfterDays" value={this.state.rule.expiresAfterDays} onChange={this.onInputChange} className="form-control" />
                </div>
                <div className="form-group col-md-3">
                    <label>Priority</label>
                    <input id="priority" value={this.state.rule.priority} onChange={this.onInputChange} className="form-control" />
                </div>
                <div className="form-group col-md-3">
                    <label>From Date</label>
                    <DateTimePicker
                        value={this.state.rule.dateFrom}
                        onChange={this.onDateFromChange} className="form-control"
                    />
                </div>
                <div className="form-group col-md-3">
                    <label>To Date</label>
                    <DateTimePicker
                        value={this.state.rule.dateTo}
                        onChange={this.onDateToChange} className="form-control"
                    />
                </div>
                <button type="submit" className="btn btn-success col-md-3">Save</button>
            </form>
        )
    }
}

function mapStateToProps(state) {
    return { currentRule: state.currentRule }
}

function mapDispatchToProps(dispatch) {
    return bindActionCreators({ saveRule: addNewRuleAction }, dispatch);
}

export default connect(mapStateToProps, mapDispatchToProps)(RuleForm);