import React,{ Component } from 'react'

export default class EnhancedComponent extends Component{
	// Used for simple 2-way binding
	// eg: <input {...this.twoWayBind('stateVariable')}/>
	twoWayBind=(property,event='onChange',valAttr='value')=>({
		[valAttr]:this.state[property],
		[event]:e=>this.setState({[property]:e.target[valAttr]}),
	})
}