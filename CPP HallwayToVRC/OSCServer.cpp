#include "OSCServer.h"

using namespace boost::asio::ip;

OSCServer::OSCServer(boost::asio::io_context& io_context) : socket_(io_context, udp::endpoint(udp::v4(), 9001))
{
	start_listening();
}

void OSCServer::start_listening()
{
}
