import React, { Component } from 'react';
import RuleForm from './ruleForm';
import RulesList from './rulesList';

export default class App extends Component {
  render() {
    return (
      <div>
        <RuleForm/>
        <RulesList/>
      </div>
    );
  }
}
