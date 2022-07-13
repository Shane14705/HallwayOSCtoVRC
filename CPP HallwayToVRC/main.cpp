#include <iostream>
#include <boost/asio/io_context.hpp>
#include "OSCServer.h"

int main(void)
{
	std::cout << "Hello World!";
	boost::asio::io_context io_context;
	OSCServer server(io_context);
	
	while (true)
	{
		io_context.run();
	}
}
