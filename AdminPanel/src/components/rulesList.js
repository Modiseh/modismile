import React, { Component } from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import { fetchRulesAction } from '../actions/index';


class RulesList extends Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <table className="table table-hover" >
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Title</th>
                        <th>Description</th>
                        <th>Version</th>
                        <th>Rate</th>
                        <th>From</th>
                        <th>To</th>
                        <th>Expires after</th>
                        <th>Priority</th>
                    </tr>
                </thead>
                <tbody>
                    {this.props.rules.map(rule =>
                        <tr key={rule.id}>
                            <td>{rule.id}</td>
                            <td>{rule.title}</td>
                            <td>{rule.description}</td>
                            <td>{rule.version}</td>
                            <td>{rule.rate}</td>
                            <td>{rule.fromDate}</td>
                            <td>{rule.toDate}</td>
                            <td>{rule.expiresDaysAfter}</td>
                            <td>{rule.priority}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        )
    }

    componentWillMount() {
        this.props.fetchRules();
    }
}

function mapStateToProps(state) {
    return { rules: state.rules };
}

function mapDispatchToProps(dispatch) {
    return bindActionCreators({ fetchRules: fetchRulesAction }, dispatch);
}

export default connect(mapStateToProps, mapDispatchToProps)(RulesList);