#include "OSCServer.h"

#include <iostream>

using namespace boost::asio::ip;

OSCServer::OSCServer(boost::asio::io_context& io_context) : socket_(io_context), vBuffer(1024)
{
	
	//incoming = boost::asio::buffer(vBuffer, vBuffer->size());
	start_listening();
}

OSCServer::~OSCServer()
{
	
}

void OSCServer::start_listening()
{

	socket_.open(udp::v4());
	socket_.bind(udp::endpoint(address::from_string("127.0.0.1"), 9001));
	socket_.async_receive_from(boost::asio::buffer(vBuffer), myEP, boost::bind(&OSCServer::handle_receive, this, boost::asio::placeholders::error, boost::asio::placeholders::bytes_transferred));
}

/*NOTE: I BELIEVE THAT THIS WILL BE CALLED FROM WHATEVER THREAD OWNS THE "IO_CONTEXT" OBJECT, * NOT* THE THREAD WHICH WAS DOING THE RECEIVING.
 * KEEP THAT IN MIND : THE IO_CONTEXT'S THREAD MAY END UP CALLING THIS CALLBACK FUNCTION, WHICH IN ORDER TO OPERATE ON THE INCOMING DATA MUST READ FROM THE BUFFER WHICH IS LOCATED ON THE SERVER OBJECT (possibly in different thread)
 *
*/
void OSCServer::handle_receive(const boost::system::error_code& error, const std::size_t numBytes)
{
	std::cout << error.message() << std::endl;
	std::cout << numBytes << std::endl;
	
	//std::cout << std::string(vBuffer.begin(), vBuffer.begin() + numBytes) << std::endl;
	for (auto i : vBuffer)
	{
		std::cout << i << std::endl;
	}

	socket_.async_receive_from(boost::asio::buffer(vBuffer), myEP, boost::bind(&OSCServer::handle_receive, this, boost::asio::placeholders::error, boost::asio::placeholders::bytes_transferred));
}


